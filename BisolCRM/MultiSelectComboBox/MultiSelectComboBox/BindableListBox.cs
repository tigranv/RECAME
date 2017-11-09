using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Collections.Specialized;

namespace CustomControls
{
    /// <summary>
    /// Extends ListBox by making the SelectedItems property read/write.
    /// ListBox does have a SelectedItems property but it is read-only. 
    /// MultiSelectListBox hides the base class's SelectedItems property.
    /// The SelectedItems property of MultiSelectListBox can participate in two way data binding 
    /// and Can be set in Xaml, whereas in the base class it can only participate in one way binding.
    /// SelectionMode should not be Single when using the SelectedItems property.
    /// By default, selection mode is Multiple.
    /// </summary>
    public class BindableListBox : ListBox
    {
        public BindableListBox()
        {
            // Add handler for when the listbox internal selection changes.
            base.SelectionChanged += new SelectionChangedEventHandler(UpdateNewClassSelectedItems);                
        }

        #region Public Properties

        /// <summary>
        /// The SelectedItems dependency property. Access to the values of the items that are 
        /// selected in the selectedItems box. If SelectionMode is Single, this property returns an array
        /// of length one.
        /// </summary>
        public static new readonly DependencyProperty SelectedItemsProperty =
           DependencyProperty.Register("SelectedItems", typeof(IList), typeof(BindableListBox),
           new FrameworkPropertyMetadata(
                  (d, e) =>
                  {
                      // When the property changes, update the selected values in the selectedItems box.
                      (d as BindableListBox).SetSelectedItemsNew(e.NewValue as IList);
                  }));
        /// <summary>
        /// Get or set the selected items.
        /// </summary>
        public new IList SelectedItems
        {
            get
            {
                return GetValue(SelectedItemsProperty) as IList;
            }
            set { SetValue(SelectedItemsProperty, value); }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Call this method to programmatically add an item to the selected items collection.
        /// Because this class hides ListBox.SelectedItems, it is necessary add the value directly
        /// to the base class's collection for all the related events to properly propagate.
        /// </summary>
        protected int SelectItem(object item)
        {
            return base.SelectedItems.Add(item);
        }

        /// <summary>
        /// Call this method to programmatically add an item to the selectedItems that is displayed in 
        /// the listbox. NOTE: For the selectedItems box display to update, ItemsSource must impliment INotifyCollectionChanged
        /// such as ObservableCollection.
        /// </summary>
        protected int AddItem(object item)
        {
            if (ItemsSource != null)
            {
                return (ItemsSource as IList).Add(item);
            }
            else
            {
                return base.Items.Add(item);
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// Synchronizes the selected items of this class with the selected items of the base class.
        /// </summary>
        void UpdateNewClassSelectedItems(object sender, SelectionChangedEventArgs e)
        {
            // If null, then we aren't bound to.
            if (SelectedItems == null)
                return;

            foreach (object o in e.AddedItems)
                SelectedItems.Add(o);
            foreach (object o in e.RemovedItems)
                SelectedItems.Remove(o);
        }

        /// <summary>
        /// Synchronizes the selected items with the selected values. 
        /// </summary>
        private void SetSelectedItemsNew(IList newSelectedItems)
        {
            if (newSelectedItems == null)
                throw new InvalidOperationException("Collection cannot be null");

            // Remove the event handler to prevent recursion.
            base.SelectionChanged -= new SelectionChangedEventHandler(UpdateNewClassSelectedItems);

            base.SetSelectedItems(SelectedItems);

            // Reestablish the event handler.
            base.SelectionChanged += new SelectionChangedEventHandler(UpdateNewClassSelectedItems);

            // Add a collection changed handler to the new list, if it supports the interface.
            AddSelectedItemsChangedHandler(newSelectedItems as INotifyCollectionChanged);
        }

        private void AddSelectedItemsChangedHandler(INotifyCollectionChanged collection)
        {
            if (collection != null)
                collection.CollectionChanged += new NotifyCollectionChangedEventHandler(SelectedItems_CollectionChanged);
        }

        private void RemoveSelectedItemsChangedHandler(INotifyCollectionChanged collection)
        {
            if (collection != null)
                collection.CollectionChanged -= new NotifyCollectionChangedEventHandler(SelectedItems_CollectionChanged);
        }

        void SelectedItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            base.SelectionChanged -= new SelectionChangedEventHandler(UpdateNewClassSelectedItems);
            base.SetSelectedItems(SelectedItems);
            base.SelectionChanged += new SelectionChangedEventHandler(UpdateNewClassSelectedItems);
        }

        #endregion
    }

}
