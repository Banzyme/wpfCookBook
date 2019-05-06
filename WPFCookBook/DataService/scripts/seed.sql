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

--Insert seed to module sections
insert WpfCourseSection(SectionID, Title, WpfCourseModule_ID)
 values (NEWID(), 'Quick intro', 1);

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

 --Insert seed to module sections
 insert WpfCourseSectionItem(SectionItemID, Title,Subtitle, Content, WpfCourseSection_ID)
 values (NEWID(), 'Terminology', 
 'Taming the jargon',
 '1. A control - Defines any element that the user interacts with in a WPF application',
  2);