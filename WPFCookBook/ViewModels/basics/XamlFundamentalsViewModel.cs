﻿using FsWpfControls.FsRichTextBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using WPFCookBook.Common;
using WPFCookBook.DataService;
using WPFCookBook.Entities;

namespace WPFCookBook.ViewModels.basics
{
    public class XamlFundamentalsViewModel : BindableBase
    {
        private readonly ApplicationDBContext _context = new ApplicationDBContext();
        private WpfCourseSection section;
        private WpfCourseSectionItem currentTopic = null;

        #region constructor
        public XamlFundamentalsViewModel()
        {
            OnSaveChangesCommand = new CommandTemplate<FsRichTextBox>(OnSaveChanges);
            section = _context.CourseSections.Include("SectionTopics").SingleOrDefault(x => x.Title.Contains("XAML Fundamentals"));
        }
        #endregion

        #region Properties
        public CommandTemplate<FsRichTextBox> OnSaveChangesCommand { get; private set; }
        public ObservableCollection<WpfCourseSectionItem> TopicsList
        {
            get
            {
                ObservableCollection<WpfCourseSectionItem> result = new ObservableCollection<WpfCourseSectionItem>(section.SectionTopics.ToList());
                return result;
            }
        }
        #endregion


        #region Private methods

        private void OnSaveChanges(FsRichTextBox EditBox)
        {
            EditBox.UpdateDocumentBindings();

            currentTopic = (WpfCourseSectionItem)EditBox.DataContext;
            PersistTwoWayPropToDB(this.currentTopic.ID, this.currentTopic.Content);
        }


        private void PersistTwoWayPropToDB(long ID, string val)
        {
            // Todo: Add loader
            var res = _context.CourseSectionItems.SingleOrDefault(x => x.ID == ID);
            res.Content = val;
            _context.SaveChangesAsync();
        }

        #endregion

    }
}