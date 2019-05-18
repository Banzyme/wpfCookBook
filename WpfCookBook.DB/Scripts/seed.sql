--Insert seed data into modules table
insert ModuleDao(ModuleID, Name) values (NEWID(), 'Basics(Getting started)');
insert ModuleDao(ModuleID, Name) values (NEWID(), 'Controls');
insert ModuleDao(ModuleID, Name) values (NEWID(), 'Layouts');
insert ModuleDao(ModuleID, Name) values (NEWID(), 'Data binding');
insert ModuleDao(ModuleID, Name) values (NEWID(), 'Data Templates');
insert ModuleDao(ModuleID, Name) values (NEWID(), 'Events');
insert ModuleDao(ModuleID, Name) values (NEWID(), 'Commands');
insert ModuleDao(ModuleID, Name) values (NEWID(), 'Resources');
insert ModuleDao(ModuleID, Name) values (NEWID(), 'Styles');
insert ModuleDao(ModuleID, Name) values (NEWID(), 'Media');
insert ModuleDao(ModuleID, Name) values (NEWID(), 'Graphics and Animations');
insert ModuleDao(ModuleID, Name) values (NEWID(), 'Misc');
insert ModuleDao(ModuleID, Name) values (NEWID(), 'Advanced topics');
insert ModuleDao(ModuleID, Name) values (NEWID(), 'References');
insert ModuleDao(ModuleID, Name) values (NEWID(), 'FAQ');

--Insert seed to module sections - Tree view header
-- 1.BASICS
insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Quick intro', 1);

insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'XAML fundamentals', 1);

insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'What is WPF?', 1);

insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Real life WPF examples', 1);

insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Tutorial - Self service insuarence', 1);


--2.CONTROLS - Child item on tree view
insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Intro to WPF controls', 2);

insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Text controls', 2);
 insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Buttons', 2);
 insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Checkboxes and Radio Buttons', 2);
 insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'List Views', 2);

  insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Data Grid', 2);

   insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Tree View', 2);

 insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Menus and Toolbars', 2);
 insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'HyperLinks', 2);

  insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Misc', 2);


--3. Layouts
insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'WPF Layouts overview', 3);

insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Grid Panel', 3);

insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Stack Panel', 3);

insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Dock Panel', 3);

insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Canvas panel', 3);

insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Wrap Panel', 3);

 insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Nested Layouts', 3);

 insert ChapterDao(SectionID, Title, ParentModule_ID)
 values (NEWID(), 'Tabs', 3);


 --Insert seed to module sections - Tab control
  insert TopicDao(SectionItemID, Title,Subtitle, Content, ChapterDao_ID)
 values (NEWID(), 'Desktop applications', 
 'Really? Is this even necessary?',
'<FlowDocument PagePadding="5,0,5,0" AllowDrop="True" xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation">
 <Paragraph>Text generated by app back-end</Paragraph></FlowDocument>',
  2);


 insert TopicDao(SectionItemID, Title,Subtitle, Content, ChapterDao_ID)
 values (NEWID(), 'Terminology', 
 'Taming the jargon',
 '1. A control - Defines any element that the user interacts with in a WPF application',
  6);