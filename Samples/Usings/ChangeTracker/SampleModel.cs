using System.Collections.ObjectModel;

namespace Samples.Usings.ChangeTracker
{
    public class SampleObject : BaseChangeTracker
    {
        
        private string mDisplayName;
        /// <summary>
        /// Наименование
        /// </summary>
        public string DisplayName
        {
            get { return mDisplayName; }
            set
            {
                ApplyPropertyChange<SampleObject, string>(ref mDisplayName, p => p.DisplayName, value);
            }
        }

        private ObservableCollection<SampleObject> mChilds;
        /// <summary>
        /// Детки
        /// </summary>
        public ObservableCollection<SampleObject> Childs
        {
            get { return mChilds; }
            set
            {
                ApplyCollectionChange<SampleObject, SampleObject>(ref mChilds, p => p.Childs, value);
            }
        }
    }
}
