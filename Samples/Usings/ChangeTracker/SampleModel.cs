using System.Collections.ObjectModel;

namespace Samples.Usings.ChangeTracker
{
    public class SampleModel : BaseChangeTracker
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
                ApplyPropertyChange<SampleModel, string>(ref mDisplayName, p => p.DisplayName, value);
            }
        }

        private ObservableCollection<SampleModel> mChilds;
        /// <summary>
        /// Детки
        /// </summary>
        public ObservableCollection<SampleModel> Childs
        {
            get { return mChilds; }
            set
            {
                ApplyCollectionChange<SampleModel, SampleModel>(ref mChilds, p => p.Childs, value);
            }
        }
    }
}
