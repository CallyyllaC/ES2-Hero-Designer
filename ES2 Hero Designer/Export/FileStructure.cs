using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ES2_Hero_Designer.Export
{
    class FileStructure
    {
        public static void CreateFolders(string Dir, string RootFolder)
        {
            if (!Directory.Exists($"{Dir}{RootFolder}"))
                Directory.CreateDirectory($"{Dir}{RootFolder}");

            if (!Directory.Exists($"{Dir}{RootFolder}\\Gui"))
                Directory.CreateDirectory($"{Dir}{RootFolder}\\Gui");

            if (!Directory.Exists($"{Dir}{RootFolder}\\Localization"))
                Directory.CreateDirectory($"{Dir}{RootFolder}\\Localization");

            if (!Directory.Exists($"{Dir}{RootFolder}\\Localization\\english"))
                Directory.CreateDirectory($"{Dir}{RootFolder}\\Localization\\english");

            if (!Directory.Exists($"{Dir}{RootFolder}\\Resources"))
                Directory.CreateDirectory($"{Dir}{RootFolder}\\Resources");

            if (!Directory.Exists($"{Dir}{RootFolder}\\Resources\\Gui"))
                Directory.CreateDirectory($"{Dir}{RootFolder}\\Resources\\Gui");

            if (!Directory.Exists($"{Dir}{RootFolder}\\Simulation"))
                Directory.CreateDirectory($"{Dir}{RootFolder}\\Simulation");
        }

        public static void CreateFiles(string Dir, string RootFolder, string Name, string Desc, string WsTitle, string WsDesc, string WsAuth, string WsRelease, string Affinity, string Class, string Politics, string ShipDesign, string SkillTree1, string SkillTree2, string SkillTree3, byte[] Large, byte[] Medium, byte[] Mood, byte[] ModIcon, List<CustomHeroSkill> skills, List<SkillTree> trees)
        {
            string NameMod = Name.Replace(" ", "");

            File.WriteAllText($"{Dir}{RootFolder}\\{NameMod}.xml", FormatXml(TemplateMain.Replace("%NameMod%", NameMod).Replace("%WsTitle%", WsTitle).Replace("%WsDescription%", WsDesc).Replace("%WsAuth%", WsAuth).Replace("%WsRelease%", WsRelease)));
            File.WriteAllBytes($"{Dir}{RootFolder}\\ModIcon.png", ModIcon);


            File.WriteAllBytes($"{Dir}{RootFolder}\\Resources\\Gui\\{NameMod}Large.png", Large);
            File.WriteAllBytes($"{Dir}{RootFolder}\\Resources\\Gui\\{NameMod}Medium.png", Medium);
            File.WriteAllBytes($"{Dir}{RootFolder}\\Resources\\Gui\\{NameMod}Mood.png", Mood);

            string skillslist = "";
            string HeroSkillGui = "";
            string HeroSkillLocales = "";
            string HeroSkillLocalesAssets = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">";

            foreach (CustomHeroSkill Item in skills)
            {
                skillslist = skillslist + "\n" + $"<Skill Name=\"{Item.Name}\" />";

                HeroSkillGui = HeroSkillGui + @"<ExtendedGuiElement Name=""" + Item.Name + @"""> <Title>%" + Item.Name + @"_Title</Title> <Description>%" + Item.Name + @"_Description</Description> <Icons> <Icon Size=""Small"" Path=""" + Item.Icon + @""" /> </Icons> </ExtendedGuiElement>";

                HeroSkillLocales = HeroSkillLocales + @"<LocalizationPair Name=""%" + Item.Name + @"_Title"">" + Item.Name.Replace("_", " ") + @"</LocalizationPair> <LocalizationPair Name=""%" + Item.Name + @"_Description"">" + Item.Desc + @"</LocalizationPair>";
            }

            foreach (var tree in trees)
            {
                HeroSkillGui = HeroSkillGui + @"<ExtendedGuiElement Name=""" + tree.Name + @"""><Title>%" + tree.Name + @"Title</Title><Description>%" + tree.Name + @"Description</Description><Icons><Icon Size=""Small"" Path=""/Atlased/Hero/HeroesHeroesSmall"" /></Icons><Color Red=""" + tree.Red + @""" Green=""" + tree.Green + @""" Blue=""" + tree.Blue + @""" Alpha=""" + tree.Alpha + @"""/></ExtendedGuiElement><GuiElement Name=""Category" + tree.Name + @"""><Title>%Category" + tree.Name + @"Title</Title><Icons><Icon Size=""Small"" Path=""/Atlased/Hero/HeroesHeroesSmall"" /></Icons></GuiElement>";

                HeroSkillGui = HeroSkillGui + @"<GuiElement Name=""Category" + tree.Name + @"""><Title>%Category" + tree.Name + @"Title</Title><Icons><Icon Size=""Small"" Path=""Bitmaps/Atlased/Affinities/AffinityPrimitivesSmall"" /></Icons></GuiElement>";

                HeroSkillLocales = HeroSkillLocales + @"<LocalizationPair Name=""%Category" + tree.Name + @"Title"">" + tree.Name.Replace("_", " ") + @" Skill</LocalizationPair> <LocalizationPair Name=""%" + tree.Name + @"Title"">" + tree.Name.Replace("_", " ") + @"</LocalizationPair> <LocalizationPair Name=""%" + tree.Name + @"Description"">" + tree.Desc + @"</LocalizationPair>";

                HeroSkillLocalesAssets = HeroSkillLocalesAssets + @"<LocalizationPair Name=""%" + tree.Name + @"Title"">" + tree.Name.Replace("_", " ") + @"</LocalizationPair><LocalizationPair Name=""%" + tree.Name + @"Description"">" + tree.Desc + @"</LocalizationPair>";

                foreach (var skill in tree.Skills)
                {
                    skillslist = skillslist + "\n" + $"<Skill Name=\"{skill.Item2.Name}\" />";

                    HeroSkillGui = HeroSkillGui + @"<ExtendedGuiElement Name=""" + skill.Item2.Name + @"""> <Title>%" + skill.Item2.Name + @"_Title</Title> <Description>%" + skill.Item2.Name + @"_Description</Description> <Icons> <Icon Size=""Small"" Path=""" + skill.Item2.Icon + @""" /> </Icons> </ExtendedGuiElement>";

                    HeroSkillLocales = HeroSkillLocales + @"<LocalizationPair Name=""%" + skill.Item2.Name + @"_Title"">" + skill.Item2.Name.Replace("_"," ") + @"</LocalizationPair> <LocalizationPair Name=""%" + skill.Item2.Name + @"_Description"">" + skill.Item2.Desc + @"</LocalizationPair>";
                }
            }

            HeroSkillLocalesAssets = HeroSkillLocalesAssets + @"</Datatable>";


            File.WriteAllText($"{Dir}{RootFolder}\\Localization\\english\\ES2_Localization_Locales.xml", FormatXml(TemplateLocales.Replace("%NameMod%", NameMod).Replace("%Name%", Name).Replace("%Desc%", Desc).Replace("%HeroSkillLocales%", HeroSkillLocales)));
            File.WriteAllText($"{Dir}{RootFolder}\\Localization\\english\\ES2_Localization_Assets_Locales.xml", FormatXml(HeroSkillLocalesAssets));
            File.WriteAllText($"{ Dir}{RootFolder}\\Gui\\GuiElements.xml", FormatXml(TemplateGui.Replace("%NameMod%", NameMod).Replace("%HeroSkillTree%", HeroSkillGui)));
            File.WriteAllText($"{Dir}{RootFolder}\\Simulation\\HeroDefinitions.xml", FormatXml(TemplateHero.Replace("%NameMod%", NameMod).Replace("%Affinity%", Affinity).Replace("%Class%", Class).Replace("%Politics%", Politics).Replace("%ShipDesign%", ShipDesign).Replace("%SkillTree1%", SkillTree1).Replace("%SkillTree2%", SkillTree2).Replace("%SkillTree3%", SkillTree3).Replace("%SkillsList%", skillslist)));

            TemplateSkill(Dir, RootFolder, skills, trees);
            TemplateTree(Dir, RootFolder, trees);
            TemplateSim(Dir, RootFolder, skills, trees);
        }


        //Default XML's taken from the mod example

        private static string TemplateMain = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:noNamespaceSchemaLocation=""Documentation/Schemas/Amplitude.Unity.Runtime.RuntimeModule.xsd"">

	<RuntimeModule Name=""%NameMod%"" Type=""Extension"" Version=""1.0"">

        <Title>%WsTitle%</Title>
        <Description>%WsDescription%</Description>
        <Author>%WsAuth%</Author>
        <Homepage>https://github.com/CallyyllaC/ES2-Hero-Designer/</Homepage>

        <PreviewImageFile>ModIcon.png</PreviewImageFile>
        <ReleaseNotes>%WsRelease%</ReleaseNotes>
        <Tags>Gameplay, Heroes</Tags>

		<Plugins>		
    		<DatabasePlugin DataType=""Amplitude.Unity.Gui.GuiElement, Assembly-CSharp-firstpass"">
			    <ExtraTypes>
		    			<ExtraType DataType=""HeroGuiElement, Assembly-CSharp"" />
	    				<ExtraType DataType=""Amplitude.Unity.Gui.ExtendedGuiElement, Assembly-CSharp-firstpass"" />
    			</ExtraTypes>
			    <FilePath>Gui/GuiElements.xml</FilePath>
		    </DatabasePlugin>

            <DatabasePlugin DataType=""HeroDefinition, Assembly-CSharp"">
                <FilePath>Simulation/HeroDefinitions.xml</FilePath>
            </DatabasePlugin>

            <DatabasePlugin DataType=""HeroSkillDefinition, Assembly-CSharp"">
                <FilePath>Simulation/HeroSkillDefinitions.xml</FilePath>
            </DatabasePlugin>

            <DatabasePlugin DataType=""HeroSkillTreeDefinition, Assembly-CSharp"">
                <FilePath>Simulation/HeroSkillTreeDefinitions.xml</FilePath>
            </DatabasePlugin>
			
			<DatabasePlugin DataType=""Amplitude.Unity.Simulation.SimulationDescriptor, Assembly-CSharp-firstpass"">
				<FilePath>Simulation/SimulationDescriptors.xml</FilePath>
			</DatabasePlugin>

            <DatabasePlugin DataType=""FactionTrait, Assembly-CSharp"">
                <ExtraTypes>
                    <ExtraType DataType = ""FactionAffinityMapping, Assembly-CSharp""/>
                </ExtraTypes>
                <FilePath>Simulation/FactionTraits.xml</FilePath>
            </DatabasePlugin>

            <LocalizationPlugin DefaultLanguage=""english"">
				<Directory>Localization</Directory>
			</LocalizationPlugin>
		</Plugins>

	</RuntimeModule>
</Datatable>";


        private static readonly string TemplateGui = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:noNamespaceSchemaLocation=""../Documentation/Schemas/Amplitude.Unity.Gui.GuiElement.xsd"">

    <HeroGuiElement Name=""%NameMod%"">
        <Title>%%NameMod%Title</Title>
        <Description>%%NameMod%Description</Description>
        <Icons>
            <Icon Size=""Medium"" Path=""Gui/%NameMod%Medium""/>
            <Icon Size=""Large"" Path=""Gui/%NameMod%Large""/>
            <Icon Size=""Mood"" Path=""Gui/%NameMod%Mood""/>
        </Icons>
    </HeroGuiElement>

    %HeroSkillTree%

</Datatable>";


        private static readonly string TemplateLocales = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:noNamespaceSchemaLocation=""../../Documentation/Schemas/Amplitude.Unity.Localization.LocalizationDatatableElement.xsd"">

	<LocalizationPair Name=""%%NameMod%Title"">%Name%</LocalizationPair>
	<LocalizationPair Name=""%%NameMod%Description"">%Desc%</LocalizationPair>
  %HeroSkillLocales%
</Datatable>";


        private static readonly string TemplateHero = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:noNamespaceSchemaLocation=""../Documentation/Schemas/HeroDefinition.xsd"">

    <HeroDefinition Name=""%NameMod%"">
        
        %SkillsList%

        <Affinity Name=""%Affinity%""/>
        <Class Name=""%Class%""/>
        <Politics Name=""%Politics%""/>

        <ShipDesign Name=""%ShipDesign%""/>

        <SkillTree Name=""%SkillTree1%""/>
        <SkillTree Name=""%SkillTree2%""/>
        <SkillTree Name=""%SkillTree3%""/>
        
        <LevelUpRuleReference Name=""HeroLevelUpRule""/>
    </HeroDefinition>

</Datatable>";


        private static void TemplateSkill(string Dir, string RootFolder, List<CustomHeroSkill> list, List<SkillTree> treelist)
        {
            string x = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
  <Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:noNamespaceSchemaLocation=""../Documentation/Schemas/HeroSkillDefinition.xsd"">
";
            foreach (CustomHeroSkill skill in list)
            {
                x = x + @"<HeroSkillDefinition Name=""" + skill.Name + @"""> ";//HEROSKILL
                string intro = @"<SkillLevel Name=""%SkillName%_%SkillLevel%"">";//HEROSKILL
                string outro = @"</SkillLevel>";
                x = $"{x}\n{intro.Replace("%SkillName%", skill.Name).Replace("%SkillLevel%", skill.level.Level)}{skill.level.SkillXML.Replace("%SkillName%", skill.Name + "_" + skill.level.Level).Replace("%SkillLevel%", skill.level.Level)}{outro}";
                x = x + @"</HeroSkillDefinition>";
            }

            foreach (SkillTree tree in treelist)
            {
                foreach (Tuple<int, CustomSkill> skill in tree.Skills)
                {
                    x = x + @"<HeroSkillDefinition Name=""" + skill.Item2.Name + @""">";
                    foreach (SkillLevel level in skill.Item2.Levels)
                    {
                        x = x + @"<SkillLevel Name=""" + $"{skill.Item2.Name}_{level.Level}" + @""">";
                        x = x + level.SkillXML.Replace("%SkillLevel%", level.Level).Replace("%SkillName%", skill.Item2.Name + "_" + level.Level);
                        x = x + @"</SkillLevel>";
                    }
                    x = x + @"</HeroSkillDefinition>";
                }
            }

            x = x + " </Datatable>";
            x = FormatXml(x);

            File.WriteAllText($"{Dir}{RootFolder}\\Simulation\\HeroSkillDefinitions.xml", x);
        }

        private static void TemplateSim(string Dir, string RootFolder, List<CustomHeroSkill> list, List<SkillTree> treelist)
        {
            string y = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
  <Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:noNamespaceSchemaLocation=""../Documentation/Schemas/Amplitude.Unity.Simulation.SimulationDescriptor.xsd"">
";

            foreach (CustomHeroSkill skill in list)
            {
                y = $"{y}\n{skill.level.SimDescXML.Replace("%SkillName%", skill.Name + "_" + skill.level.Level)}";
            }
            foreach (SkillTree tree in treelist)
            {
                foreach (Tuple<int, CustomSkill> skill in tree.Skills)
                {
                    foreach (SkillLevel level in skill.Item2.Levels)
                    {
                        y = $"{y}\n{level.SimDescXML.Replace("%SkillName%", skill.Item2.Name + "_" + level.Level)}";
                    }
                }
            }

            y = y + "</Datatable>";
            y = FormatXml(y);

            File.WriteAllText($"{Dir}{RootFolder}\\Simulation\\SimulationDescriptors.xml", y);
        }

        private static void TemplateTree(string Dir, string RootFolder, List<SkillTree> list)
        {
            string x = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
  <Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:noNamespaceSchemaLocation=""../Schemas/HeroSkillTreeDefinition.xsd"">
          ";

            foreach (SkillTree tree in list)
            {
                var stages = tree.Skills.GroupBy(c => c.Item1).Select(c => c.ToList()).ToList();
                x = x + @"<HeroSkillTreeDefinition Name=""" + tree.Name + @""">";
                foreach (var stage in stages)
                {
                    x = x + @"<Stage Level=""" + stage[0].Item1 + @""">";
                    foreach (var skill in stage)
                    {
                        x = x + @"<Skill> <SkillDefinition Name=""" + skill.Item2.Name + @"""/> </Skill>";
                    }
                    x = x + @"</Stage>";
                }
                x = x + @"</HeroSkillTreeDefinition>";
            }
            x = x + "</Datatable>";
            x = FormatXml(x);

            File.WriteAllText($"{Dir}{RootFolder}\\Simulation\\HeroSkillTreeDefinitions.xml", x);
        }

        public static string FormatXml(string xml)
        {
            try
            {
                XDocument doc = XDocument.Parse(xml, LoadOptions.SetLineInfo);
                return doc.ToString();
            }
            catch
            {
                return xml;
            }
        }
    }
}
