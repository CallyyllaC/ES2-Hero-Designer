﻿using System.IO;

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

        public static void CreateFiles(string Dir, string RootFolder, string Name, string Desc, string WsTitle, string WsDesc, string WsAuth, string WsRelease, string Affinity, string Class, string Politics, string ShipDesign, string SkillTree1, string SkillTree2, string SkillTree3, byte[] Large, byte[] Medium, byte[] Mood, byte[] ModIcon)
        {
            string NameMod = Name.Replace(" ", "");

            File.WriteAllText($"{Dir}{RootFolder}\\{NameMod}.xml", TemplateMain.Replace("%NameMod%", NameMod).Replace("%WsTitle%", WsTitle).Replace("%WsDescription%", WsDesc).Replace("%WsAuth%", WsAuth).Replace("%WsRelease%", WsRelease));
            File.WriteAllBytes($"{Dir}{RootFolder}\\ModIcon.png", ModIcon);
            
            File.WriteAllText($"{Dir}{RootFolder}\\Gui\\GuiElements.xml", TemplateGui.Replace("%NameMod%", NameMod));

            File.WriteAllText($"{Dir}{RootFolder}\\Localization\\english\\ES2_Localization_Locales.xml", TemplateLocales.Replace("%NameMod%", NameMod).Replace("%Name%", Name).Replace("%Desc%", Desc));
            
            File.WriteAllBytes($"{Dir}{RootFolder}\\Resources\\Gui\\{NameMod}Large.png", Large);
            File.WriteAllBytes($"{Dir}{RootFolder}\\Resources\\Gui\\{NameMod}Medium.png", Medium);
            File.WriteAllBytes($"{Dir}{RootFolder}\\Resources\\Gui\\{NameMod}Mood.png", Mood);

            File.WriteAllText($"{Dir}{RootFolder}\\Simulation\\HeroDefinitions.xml", TemplateHero.Replace("%NameMod%", NameMod).Replace("%Affinity%", Affinity).Replace("%Class%", Class).Replace("%Politics%", Politics).Replace("%ShipDesign%", ShipDesign).Replace("%SkillTree1%", SkillTree1).Replace("%SkillTree2%", SkillTree2).Replace("%SkillTree3%", SkillTree3));

            //File.WriteAllText($"{Dir}{RootFolder}\\Simulation\\HeroSkillDefinitions.xml", TemplateSkill);
            //File.WriteAllText($"{Dir}{RootFolder}\\Simulation\\SimulationDescriptors.xml", TemplateSimulation);
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
				</ExtraTypes>
                <FilePath>Gui/GuiElements.xml</FilePath>
			</DatabasePlugin>

            <DatabasePlugin DataType=""HeroDefinition, Assembly-CSharp"">
                <FilePath>Simulation/HeroDefinitions.xml</FilePath>
            </DatabasePlugin>

            <!--<DatabasePlugin DataType=""HeroSkillDefinition, Assembly-CSharp"">
                <FilePath>Simulation/HeroSkillDefinitions.xml</FilePath>
            </DatabasePlugin>
			
			<DatabasePlugin DataType=""Amplitude.Unity.Simulation.SimulationDescriptor, Assembly-CSharp-firstpass"">
				<FilePath>Simulation/SimulationDescriptors.xml</FilePath>
			</DatabasePlugin>-->

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
	
</Datatable>";


        private static readonly string TemplateLocales = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:noNamespaceSchemaLocation=""../../Documentation/Schemas/Amplitude.Unity.Localization.LocalizationDatatableElement.xsd"">

	<LocalizationPair Name=""%%NameMod%Title"">%Name%</LocalizationPair>
	<LocalizationPair Name=""%%NameMod%Description"">%Desc%</LocalizationPair>
  
</Datatable>";


        private static readonly string TemplateHero = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:noNamespaceSchemaLocation=""../Documentation/Schemas/HeroDefinition.xsd"">

    <HeroDefinition Name=""%NameMod%"">
        
        <!--<Skill Name=""HeroSkillExample01""/>
        <Skill Name=""HeroSkillExample02""/>-->

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


        //private static readonly string TemplateSkill = @"";


        //private static readonly string TemplateSimulation = @"";
    }
}
