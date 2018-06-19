using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity.Core.Objects;
using System.Windows.Controls.Primitives;

namespace Eleot
{
    /// <summary>
    ///// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Personals : Window
    {
        private int _currentPosition;
        private SqlCommandBuilder cmd = null;
        private SqlConnection conn;
        private string cs = "", sql = "";
        private SqlDataAdapter da = null;
        private System.Windows.Data.CollectionViewSource personalViewSource;
        private DataSet set = null;

        public Personals()
        {
            InitializeComponent();
            conn = new SqlConnection();
            var ConnStr = ConfigurationManager.AppSettings["Eleot.Properties.Settings.EleotConnectionString"];
            cs = ConfigurationManager.
                ConnectionStrings["Eleot.Properties.Settings.EleotConnectionString"].ConnectionString;
            conn.ConnectionString = cs;

            this.PreviewKeyDown += (s, e) =>
            {
                if (e.Key == Key.F4)
                    SelectRowByIndex(Gr1, _currentPosition);
            };
        }

        private void Gr1_Loaded(object sender, RoutedEventArgs e)

        {
            DataGrid dataGrid = sender as DataGrid;
            dataGrid.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
        }

        private void Gr1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _currentPosition = Gr1.SelectedIndex;
            Gr1.Items.MoveCurrentToPosition(_currentPosition);
            Gr1.SelectedIndex = _currentPosition;

            IInputElement focusedElement = FocusManager.GetFocusedElement(Gr1);

            personalViewSource.View.MoveCurrentToPosition(_currentPosition);
            personalViewSource.View.Refresh();

            Keyboard.ClearFocus();
            FocusManager.SetFocusedElement(this, focusedElement);
        }

        #region future

        //public static void SelectRowByIndex(DataGrid dataGrid, int rowIndex)
        //{
        //    if (!dataGrid.SelectionUnit.Equals(DataGridSelectionUnit.FullRow))
        //        throw new ArgumentException("The SelectionUnit of the DataGrid must be set to FullRow.");

        //    if (rowIndex < 0 || rowIndex > (dataGrid.Items.Count - 1))
        //        throw new ArgumentException(string.Format("{0} is an invalid row index.", rowIndex));

        //    dataGrid.SelectedItems.Clear();
        //    /* set the SelectedItem property */
        //    object item = dataGrid.Items[rowIndex]; // = Product X
        //    dataGrid.SelectedItem = item;

        //    DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
        //    if (row == null)
        //    {
        //        /* bring the data item (Product object) into view
        //         * in case it has been virtualized away */
        //        dataGrid.ScrollIntoView(item);
        //        row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
        //    }

        //    if (row != null)
        //    {
        //        DataGridCell cell = GetCell(dataGrid, row, 0);
        //        if (cell != null)
        //            cell.Focus();
        //    }
        //}

        //public static DataGridCell GetCell(DataGrid dataGrid, DataGridRow rowContainer, int column)
        //{
        //    if (rowContainer != null)
        //    {
        //        DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
        //        if (presenter == null)
        //        {
        //            /* if the row has been virtualized away, call its ApplyTemplate() method
        //             * to build its visual tree in order for the DataGridCellsPresenter
        //             * and the DataGridCells to be created */
        //            rowContainer.ApplyTemplate();
        //            presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
        //        }
        //        if (presenter != null)
        //        {
        //            DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
        //            if (cell == null)
        //            {
        //                /* bring the column into view
        //                 * in case it has been virtualized away */
        //                dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);
        //                cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
        //            }
        //            return cell;
        //        }
        //    }
        //    return null;
        //}

        //public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        //{
        //    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
        //    {
        //        DependencyObject child = VisualTreeHelper.GetChild(obj, i);
        //        if (child != null && child is T)
        //            return (T)child;
        //        else
        //        {
        //            T childOfChild = FindVisualChild<T>(child);
        //            if (childOfChild != null)
        //                return childOfChild;
        //        }
        //    }
        //    return null;
        //}

        //private static T FindVisualChild<T>(DependencyObject element) where T : DependencyObject
        //{
        //    int childrenCount = VisualTreeHelper.GetChildrenCount(element);
        //    if (childrenCount > 0)
        //    {
        //        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
        //        {
        //            DependencyObject child = VisualTreeHelper.GetChild(element, i);
        //            if (typeof(T).IsAssignableFrom(child.GetType()))
        //            {
        //                return (T)child;
        //            }
        //            else
        //            {
        //                T candidate = FindVisualChild<T>(child);
        //                if (candidate != null)
        //                    return candidate;
        //            }
        //        }
        //    }
        //    return null;
        //}

        //public static DataGridCell GetCell(DataGrid dataGrid, DataGridRow rowContainer, int column)
        //{
        //    if (rowContainer != null)
        //    {
        //        DataGridCellsPresenter presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
        //        if (presenter == null)
        //        {
        //            /* if the row has been virtualized away, call its ApplyTemplate() method
        //             * to build its visual tree in order for the DataGridCellsPresenter
        //             * and the DataGridCells to be created */
        //            rowContainer.ApplyTemplate();
        //            presenter = FindVisualChild<DataGridCellsPresenter>(rowContainer);
        //        }
        //        if (presenter != null)
        //        {
        //            DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
        //            if (cell == null)
        //            {
        //                /* bring the column into view
        //                 * in case it has been virtualized away */
        //                dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);
        //                cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
        //            }
        //            return cell;
        //        }
        //    }
        //    return null;
        //}

        #endregion future

        /// <summary>
        /// On Enter Key, it tabs to into next cell.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Gr1_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            var uiElement = e.OriginalSource as UIElement;
            if (e.Key == Key.Enter && uiElement != null)
            {
                e.Handled = true;
                uiElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Eleot.EleotDataSet eleotDataSet = ((EleotDataSet)(FindResource("eleotDataSet")));
            // Загрузить данные в таблицу Personal. Можно изменить этот код как требуется.
            EleotDataSetTableAdapters.PersonalTableAdapter eleotDataSetPersonalTableAdapter =
                new EleotDataSetTableAdapters.PersonalTableAdapter();
            eleotDataSetPersonalTableAdapter.Fill(eleotDataSet.Personal);
            personalViewSource = ((CollectionViewSource)(FindResource("personalViewSource")));
            personalViewSource.View.MoveCurrentToFirst();
            _currentPosition = personalViewSource.View.CurrentPosition;

            sql = "select id_person,firstName,secondName,data_birth," +
                "isMale,adress,salary,position,phone from personal";
            SqlConnection conn = new SqlConnection(cs);
            da = new SqlDataAdapter(sql, conn);
            cmd = new SqlCommandBuilder(da);
            set = new DataSet();
            da.Fill(set, "myPersonalDate");
            StringBuilder sb = new StringBuilder();

            Gr1.ItemsSource = set.Tables["myPersonalDate"].DefaultView;
            Gr1.TabIndex = 0;
            KeyboardNavigation.SetTabNavigation(Gr1, KeyboardNavigationMode.Cycle);
            KeyboardNavigation.SetDirectionalNavigation(Gr1, KeyboardNavigationMode.Cycle);

            //Gr1.SelectedIndex = 0;
            Gr1.Focus();
            //SelectRowByIndex(Gr1, _currentPosition);

            //IInputElement focusedElement = FocusManager.GetFocusedElement(Gr1);
            //FocusManager.SetFocusedElement(Gr1, focusedElement);
            //DataGridCell cell = GetCell(Gr1, (DataGridRow)Gr1.SelectedItems[0], 0);
            //cell.Focus();
        }

        private static void SelectRowByIndex(DataGrid dataGrid, int rowIndex)
        {
            if (!dataGrid.SelectionUnit.Equals(DataGridSelectionUnit.FullRow))
                throw new ArgumentException("The SelectionUnit of the DataGrid must be set to FullRow.");

            if (rowIndex < 0 || rowIndex > (dataGrid.Items.Count - 1))
                throw new ArgumentException(string.Format("{0} is an invalid row index.", rowIndex));

            dataGrid.SelectedItems.Clear();
            object item = dataGrid.Items[rowIndex];
            dataGrid.SelectedItem = item;

            DataGridRow row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            if (row == null)
            {
                /* bring the data item (Product object) into view
                 * in case it has been virtualized away */
                dataGrid.ScrollIntoView(item);
                row = dataGrid.ItemContainerGenerator.ContainerFromIndex(rowIndex) as DataGridRow;
            }
            if (row != null)
            {
                DataGridCell cell = GetCell(dataGrid, row, 0);
                if (cell != null)
                    cell.Focus();
            }
        }

        private static DataGridCell GetCell(DataGrid dataGrid, DataGridRow rowContainer, int column)
        {
            if (rowContainer != null)
            {
                System.Windows.Controls.Primitives.DataGridCellsPresenter presenter
                    = FindVisualChild<System.Windows.Controls.Primitives.DataGridCellsPresenter>(rowContainer);
                if (presenter == null)
                {
                    /* if the row has been virtualized away, call its ApplyTemplate() method
                     * to build its visual tree in order for the DataGridCellsPresenter
                     * and the DataGridCells to be created */
                    rowContainer.ApplyTemplate();
                    presenter = FindVisualChild<System.Windows.Controls.Primitives.DataGridCellsPresenter>(rowContainer);
                }
                if (presenter != null)
                {
                    DataGridCell cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
                    if (cell == null)
                    {
                        /* bring the column into view
                         * in case it has been virtualized away */
                        dataGrid.ScrollIntoView(rowContainer, dataGrid.Columns[column]);
                        cell = presenter.ItemContainerGenerator.ContainerFromIndex(column) as DataGridCell;
                    }
                    return cell;
                }
            }
            return null;
        }

        private static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
}