using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace ES2_Hero_Designer.Export
{
    class Data
    {
        public static List<string> GetList(string dir, string nodename, string filename)
        {
            List<string> list = new List<string>();
            foreach (var item in Directory.GetFiles($"{dir}Public\\", $"{filename}*.xml", SearchOption.AllDirectories))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(item);
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes(nodename);
                foreach (XmlNode node in nodes)
                {
                    list.Add(node["SimulationDescriptorReference"].GetAttribute("Name"));
                }
            }
            return list;
        }

        public static List<string> GetPolitics(string dir, string nodename, string filename)
        {
            List<string> list = new List<string>();
            foreach (var item in Directory.GetFiles($"{dir}Public\\", $"{filename}*.xml", SearchOption.AllDirectories))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(item);
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes(nodename);
                foreach (XmlNode node in nodes)
                {
                    list.Add(node.Attributes["Name"].Value);
                }
            }
            return list;
        }

        public static List<string> GetListShips(string dir)
        {
            List<string> list = new List<string>();
            foreach (var item in Directory.GetFiles($"{dir}Public\\", "ShipDesignDefinitions*.xml", SearchOption.AllDirectories))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(item);
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("//ShipDesignDefinition");
                foreach (XmlNode node in nodes)
                {
                    if (node["ShipRoleReference"].GetAttribute("Name") == "ShipRoleHero")
                    {
                        list.Add(node.Attributes["Name"].Value);
                    }
                }
            }
            return list;
        }

        public static List<string> GetListSKillTree(string dir)
        {
            List<string> list = new List<string>();
            foreach (var item in Directory.GetFiles($"{dir}Public\\", "HeroSkillTreeDefinitions*.xml", SearchOption.AllDirectories))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(item);
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("//HeroSkillTreeDefinition");
                foreach (XmlNode node in nodes)
                {
                    list.Add(node.Attributes["Name"].Value);
                }
            }
            list.Sort();
            return list;
        }

        public static List<string> GetListFactionDebug(string dir)
        {
            List<string> list = new List<string>();
            foreach (var item in Directory.GetFiles($"{dir}Public\\", "FactionTraits[AffinityMapping*].xml", SearchOption.AllDirectories))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(item);
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("//FactionAffinityMapping");
                foreach (XmlNode node in nodes)
                {
                    list.Add(node.Attributes["Name"].Value);
                }
            }
            return list;
        }

        private static XmlNode GetDataFactionDebug(string dir, string faction)
        {
            XmlNode data = null;
            foreach (var item in Directory.GetFiles($"{dir}Public\\", "FactionTraits[AffinityMapping*].xml", SearchOption.AllDirectories))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(item);
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("//FactionAffinityMapping");
                foreach (XmlNode node in nodes)
                {
                    if (node.Attributes["Name"].Value == faction)
                    {
                        data = node;
                    }
                }
            }
            return data;
        }

        public static string GetXMLFactionDebug(string dir, ref CheckedListBox Heroes)
        {
            string output = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:noNamespaceSchemaLocation=""../Documentation/Schemas/FactionTrait.xsd"">";
            var List = new List<DebugHero>();
            foreach (DebugHero hero in Heroes.Items)
            {
                List.Add(hero);
            }

            var split = List.GroupBy(c => c.Faction).Select(c => c.ToList()).ToList();

            foreach (var factionlist in split)
            {
                XmlNode xml = GetDataFactionDebug(dir, factionlist[0].Faction);

                foreach (var hero in factionlist)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(@"<Command Name = ""RecruitHero"" Arguments = """ + hero.Name + @""" />");
                    XmlNode newNode = doc.DocumentElement;
                    XmlNode importNode = xml.OwnerDocument.ImportNode(newNode, false);
                    xml.PrependChild(importNode);
                }

                output = output + @"
" + xml.OuterXml;
            }

            return output + @"
</Datatable>";
        }

        public static List<HeroSkill> GetSkillList(string dir)
        {
            var sims = GetSimList(dir);
            List<HeroSkill> list = new List<HeroSkill>();
            foreach (var item in Directory.GetFiles($"{dir}Public\\", $"HeroSkillDefinitions*.xml", SearchOption.AllDirectories))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(item);
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("//HeroSkillDefinition");
                foreach (XmlNode node in nodes)
                {
                    foreach (XmlNode skill in node.SelectNodes("SkillLevel"))
                    {
                        var output = new HeroSkill { Name = skill.Attributes["Name"].Value, XML = skill.InnerXml };
                        foreach (XmlNode nod in skill.ChildNodes)
                        {
                            if (nod.Name.Contains("SimulationDescriptorReference") && nod.Name != "HeroSimulationDescriptorReference")
                            {
                                output.DescriptorReference = nod.Name;
                                output.Skill = nod.Attributes["Name"].Value;
                                sims.TryGetValue(output.Skill, out output.SimDesc);
                            }
                        }
                        list.Add(output);
                    }
                }
            }
            list = list.OrderBy(x => x.Skill).ToList();
            return list;
        }

        public static SortedDictionary<string, string> GetSimList(string dir)
        {
            SortedDictionary<string, string> list = new SortedDictionary<string, string>();
            foreach (var item in Directory.GetFiles($"{dir}Public\\", $"SimulationDescriptors*.xml", SearchOption.AllDirectories))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(item);
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = root.SelectNodes("//SimulationDescriptor");
                foreach (XmlNode node in nodes)
                {
                    string name = node.Attributes["Name"].Value;
                    list.Add(name, node.OuterXml);
                }
            }
            return list;
        }
    }
}
