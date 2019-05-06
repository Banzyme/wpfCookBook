--Insert seed data into modules table

insert WpfCourseModule(ModuleID, Name) values (NEWID(), 'Basics(Getting started)');
insert WpfCourseModule(ModuleID, Name) values (NEWID(), 'Controls');
insert WpfCourseModule(ModuleID, Name) values (NEWID(), 'Layouts');
insert WpfCourseModule(ModuleID, Name) values (NEWID(), 'Data binding');
insert WpfCourseModule(ModuleID, Name) values (NEWID(), 'Data Templates');
insert WpfCourseModule(ModuleID, Name) values (NEWID(), 'Events');
insert WpfCourseModule(ModuleID, Name) values (NEWID(), 'Commands');
insert WpfCourseModule(ModuleID, Name) values (NEWID(), 'Resources');
insert WpfCourseModule(ModuleID, Name) values (NEWID(), 'Styles');
insert WpfCourseModule(ModuleID, Name) values (NEWID(), 'Media');
insert WpfCourseModule(ModuleID, Name) values (NEWID(), 'Graphics and Animations');
insert WpfCourseModule(ModuleID, Name) values (NEWID(), 'Misc');
insert WpfCourseModule(ModuleID, Name) values (NEWID(), 'Advanced topics');
insert WpfCourseModule(ModuleID, Name) values (NEWID(), 'References');

--Insert seed to module sections - Tree view header
-- 1.BASICS
insert WpfCourseSection(SectionID, Title, WpfCourseModule_ID)
 values (NEWID(), 'Quick intro', 1);

insert WpfCourseSection(SectionID, Title, WpfCourseModule_ID)
 values (NEWID(), 'XAML fundamentals', 1);

insert WpfCourseSection(SectionID, Title, WpfCourseModule_ID)
 values (NEWID(), 'What is WPF?', 1);

insert WpfCourseSection(SectionID, Title, WpfCourseModule_ID)
 values (NEWID(), 'Real life WPF examples', 1);

insert WpfCourseSection(SectionID, Title, WpfCourseModule_ID)
 values (NEWID(), 'Tutorial - A self service insuarence signup tool', 1);


--2.CONTROLS - Child item on tree view
insert WpfCourseSection(SectionID, Title, WpfCourseModule_ID)
 values (NEWID(), 'Introduction to WPF controls', 2);

insert WpfCourseSection(SectionID, Title, WpfCourseModule_ID)
 values (NEWID(), 'Text controls', 2);
 insert WpfCourseSection(SectionID, Title, WpfCourseModule_ID)
 values (NEWID(), 'Buttons', 2);
 insert WpfCourseSection(SectionID, Title, WpfCourseModule_ID)
 values (NEWID(), 'Checkboxes and Radio Buttons', 2);
 insert WpfCourseSection(SectionID, Title, WpfCourseModule_ID)
 values (NEWID(), 'ListViews', 2);
 insert WpfCourseSection(SectionID, Title, WpfCourseModule_ID)
 values (NEWID(), 'Menus and Toolbars', 2);
 insert WpfCourseSection(SectionID, Title, WpfCourseModule_ID)
 values (NEWID(), 'HyperLinks', 2);

 --Insert seed to module sections - Tab control
  insert WpfCourseSectionItem(SectionItemID, Title,Subtitle, Content, WpfCourseSection_ID)
 values (NEWID(), 'Desktop applications', 
 'Really? Is this even necessary?',
 'Although software seems to be tilting more towards mobile and web platforms. There are still many application
 out there that run natively on desktops?',
  1);


 insert WpfCourseSectionItem(SectionItemID, Title,Subtitle, Content, WpfCourseSection_ID)
 values (NEWID(), 'Terminology', 
 'Taming the jargon',
 '1. A control - Defines any element that the user interacts with in a WPF application',
  6);