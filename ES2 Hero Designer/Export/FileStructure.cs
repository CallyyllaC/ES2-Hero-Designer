using System.IO;

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
            File.WriteAllText($"{Dir}{RootFolder}\\{Name}.xml", TemplateMain.Replace("%Name%", Name).Replace("%WsTitle%", WsTitle).Replace("%WsDescription%", WsDesc).Replace("%WsAuth%", WsAuth).Replace("%WsRelease%", WsRelease));
            File.WriteAllBytes($"{Dir}{RootFolder}\\ModIcon.png", ModIcon);
            
            File.WriteAllText($"{Dir}{RootFolder}\\Gui\\GuiElements.xml", TemplateGui.Replace("%Name%", Name));

            File.WriteAllText($"{Dir}{RootFolder}\\Localization\\english\\ES2_Localization_Locales.xml", TemplateLocales.Replace("%Name%", Name).Replace("%Desc%", Desc));
            
            File.WriteAllBytes($"{Dir}{RootFolder}\\Resources\\Gui\\{Name}Large.png", Large);
            File.WriteAllBytes($"{Dir}{RootFolder}\\Resources\\Gui\\{Name}Medium.png", Medium);
            File.WriteAllBytes($"{Dir}{RootFolder}\\Resources\\Gui\\{Name}Mood.png", Mood);

            File.WriteAllText($"{Dir}{RootFolder}\\Simulation\\HeroDefinitions.xml", TemplateHero.Replace("%Name%", Name).Replace("%Affinity%", Affinity).Replace("%Class%", Class).Replace("%Politics%", Politics).Replace("%ShipDesign%", ShipDesign).Replace("%SkillTree1%", SkillTree1).Replace("%SkillTree2%", SkillTree2).Replace("%SkillTree3%", SkillTree3));

            File.WriteAllText($"{Dir}{RootFolder}\\Simulation\\HeroSkillDefinitions.xml", TemplateSkill);
            File.WriteAllText($"{Dir}{RootFolder}\\Simulation\\SimulationDescriptors.xml", TemplateSimulation);
        }


        //Default XML's taken from the mod example

        private static string TemplateMain = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:noNamespaceSchemaLocation=""Documentation/Schemas/Amplitude.Unity.Runtime.RuntimeModule.xsd"">

	<!-- Conversion = add new files, not compatible with other mods. Standalone = replace all files, not compatible with other mods. Extension = add new files, compatible with other mods. -->
	<RuntimeModule Name=""%Name%"" Type=""Extension"" Version=""1.0"">

        <!-- Title as it appears in the workshop -->
        <Title>%WsTitle%</Title>
        <!-- Description as it appears in the workshop -->
        <Description>%WsDescription%</Description>
        <!-- Name of the author -->
        <Author>%WsAuth%</Author>
        <!-- Link to your other work -->
        <Homepage>https://github.com/CallyyllaC/ES2-Hero-Designer/</Homepage>

        <!-- Image as it appears in the workshop. Size should be 430x430 pixels -->
        <PreviewImageFile>ModIcon.png</PreviewImageFile>
        <!-- Add more content to this each time you update the mod -->
        <ReleaseNotes>%WsRelease%</ReleaseNotes>
        <!-- Available tags: AI, Art, Buildings, Gameplay, Improvements, MajorFactions, Maps, MinorFactions, Multiplayer, Other, Resources, Technologies, Units -->
        <Tags>Gameplay</Tags>

		<!-- XML files to load -->
		<Plugins>
		
			<!-- Add one DatabasePlugin for each type you modify. Available DataTypes are referenced in XmlReference.xml -->
            <DatabasePlugin DataType=""Amplitude.Unity.Gui.GuiElement, Assembly-CSharp-firstpass"">
				<!-- Some DataTypes include sub-types, they are added as following -->
				<ExtraTypes>
                    <ExtraType DataType=""HeroGuiElement, Assembly-CSharp"" />
				</ExtraTypes>
				<!-- Path leading to the files, starting from the location of this XML file. Note that you can use * to include several files at once (eg. GuiElements[*].xml) -->
                <FilePath>Gui/GuiElements.xml</FilePath>
			</DatabasePlugin>

            <DatabasePlugin DataType=""HeroDefinition, Assembly-CSharp"">
                <FilePath>Simulation/HeroDefinitions.xml</FilePath>
            </DatabasePlugin>

            <DatabasePlugin DataType=""HeroSkillDefinition, Assembly-CSharp"">
                <FilePath>Simulation/HeroSkillDefinitions.xml</FilePath>
            </DatabasePlugin>
			
			<DatabasePlugin DataType=""Amplitude.Unity.Simulation.SimulationDescriptor, Assembly-CSharp-firstpass"">
				<FilePath>Simulation/SimulationDescriptors.xml</FilePath>
			</DatabasePlugin>
			
			<!-- Add this if you replace text. Note that sub-folders must be named after the languages they contain -->
            <LocalizationPlugin DefaultLanguage=""english"">
				<Directory>Localization</Directory>
			</LocalizationPlugin>
		</Plugins>

	</RuntimeModule>
</Datatable>";


        private static readonly string TemplateGui = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:noNamespaceSchemaLocation=""../Documentation/Schemas/Amplitude.Unity.Gui.GuiElement.xsd"">

	<!-- ATTRIBUTES -->
	<!-- Name: the name of the element the GuiElement refers to -->
	
	<!-- ELEMENTS -->
	<!-- Title: the title of the technology. There must be a LocalizationPair with the same name for it to be properly displayed -->
	<!-- Description: the description of the technology. There must be a LocalizationPair with the same name for it to be properly displayed -->
	<!-- Icons: several sizes can be set for different uses -->
    <!-- ModelPath: the path to the animated model of the hero. Here, we have none so that the icons are used instead. -->

    <HeroGuiElement Name=""Neptune"">
        <Title>%%Name%Title</Title>
        <Description>%%Name%Description</Description>
        <Icons>
            <!-- These textures are used in tooltips, and in the notification if the animated model fails to load. -->
            <Icon Size=""Medium"" Path=""Gui/%Name%Medium""/>
            <Icon Size=""Large"" Path=""Gui/%Name%Large""/>
            <Icon Size=""Mood"" Path=""Gui/%Name%Mood""/>
        </Icons>
    </HeroGuiElement>
	
</Datatable>";


        private static readonly string TemplateLocales = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:noNamespaceSchemaLocation=""../../Documentation/Schemas/Amplitude.Unity.Localization.LocalizationDatatableElement.xsd"">

	<LocalizationPair Name=""%%Name%Title"">%Name%</LocalizationPair>
	<LocalizationPair Name=""%%Name%Description"">%Desc%</LocalizationPair>
  
</Datatable>";


        private static readonly string TemplateHero = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:noNamespaceSchemaLocation=""../Documentation/Schemas/HeroDefinition.xsd"">

    <!-- Heroes each have a specific set of data. Their name must be unique. -->
    <HeroDefinition Name=""%Name%"">
        
        <!-- These are the starting hero's skills. There is no limit on the number of starting skills. -->
        <!-- <Skill Name=""HeroSkillExample01""/> -->
        <!-- <Skill Name=""HeroSkillExample02""/> -->

        <!-- A hero has an affinity, class and politics. -->
        <Affinity Name=""%Affinity%""/>
        <Class Name=""%Class%""/>
        <Politics Name=""%Politics%""/>

        <!-- The ship design of the hero must be a Hero ship design (with role ""ShipRoleHero"") -->
        <ShipDesign Name=""%ShipDesign%""/>

        <!-- The GUI supports only 3 skill trees so far. It's recommended to have matching skill trees and affinity/class, but you can do otherwise. -->
        <SkillTree Name=""%SkillTree1%""/>
        <SkillTree Name=""%SkillTree2%""/>
        <SkillTree Name=""%SkillTree3%""/>
        
        <!-- The levelup rule sets the XP needed to gain a level. This must be the same required XP as the hero's ship. -->
        <LevelUpRuleReference Name=""HeroLevelUpRule""/>
    </HeroDefinition>

</Datatable>";


        private static readonly string TemplateSkill = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:noNamespaceSchemaLocation=""../Documentation/Schemas/HeroSkillDefinition.xsd"">

    <!-- Hero skills have levels, with different effects, which can be on 3 targets: the hero itself, the hero's ship, or the senator object in the senate, if the hero is a representative -->
    <!-- Some skills have several levels, these ones are starting skills and need only one. -->

    <!-- A skill with one level with one SimulationDescriptor. -->
    <HeroSkillDefinition Name=""HeroSkillExample01"">
        <SkillLevel Name=""HeroSkillExample01_1"">
            <!-- Effect applied on ship -->
            <ShipSimulationDescriptorReference Name=""HeroSkillExampleMissile""/>
            <!-- MasteryLevels represent the gauges in GUI -->
            <MasteryLevel Class=""HeroMasteryCommand"" Levels=""1""/>
        </SkillLevel>
    </HeroSkillDefinition>

    <!-- A skill with one level with one SimulationDescriptor. -->
    <HeroSkillDefinition Name=""HeroSkillExample02"">
        <SkillLevel Name=""HeroSkillExample02_1"">
            <!-- Effect applied on hero -->
            <HeroSimulationDescriptorReference Name=""HeroSkillExampleDefense""/>
            <MasteryLevel Class=""HeroMasteryCommand"" Levels=""1""/>
        </SkillLevel>
    </HeroSkillDefinition>

</Datatable>";


        private static readonly string TemplateSimulation = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
<Datatable xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xsi:noNamespaceSchemaLocation=""../Documentation/Schemas/Amplitude.Unity.Simulation.SimulationDescriptor.xsd"">

    <!-- Apply a missile damage bonus on the hero's fleet -->
    <SimulationDescriptor Name=""HeroSkillExampleMissile"" Type=""HeroSkill"">
        <!-- Increase the value on the fleet, it'll apply on all the missile damage it deals -->
        <Modifier TargetProperty=""ShipDamageMissile""	                    Operation=""Percent""	    Value=""0.20""    Path=""./ClassGarrisonFleet"" />
    </SimulationDescriptor>

    <!-- Apply a defense bonus on system -->
    <SimulationDescriptor Name=""HeroSkillExampleDefense"" Type=""HeroSkill"">
        <!-- Note: flat damage dealt to a side of the ground battle is named ""bombardment damage"". -->
        <Modifier TargetProperty=""GroundBattleBombardmentAttackerDamages""	Operation=""Addition""	Value=""200""		Path=""./ClassColonizedStarSystem"" />
    </SimulationDescriptor>

</Datatable>";
    }
}
