//using App1.Views;
using App1.Models;
using App1.ViewModels;
using App1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.View
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ListViewModelMain lvmm = new ListViewModelMain();
        DishViewModel dvm = new DishViewModel();
        SpecialOfferViewModel sovm = new SpecialOfferViewModel();
        ListViewModel lvm = new ListViewModel();

        ICommand GoToSpecialItemListCommand;
        ICommand GoToNewListPageCommand;

        ListView currentListView = null;

        public MainPage()
        {
            InitializeComponent();


            GoToSpecialItemListCommand = new Command(() => Navigation.PushAsync(new SpecialOffersPage()));
            GoToNewListPageCommand = new Command(() => Navigation.PushAsync(new NewListPage()));

            BindingContext = dvm;

            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#2BED79");

            AnimateImageButton(AddNewItemButton, 0, 120, 0);
            AnimateImageButton(navButton, 0, -120, 0);



        }

        private void ImageButton_Clicked_House(object sender, EventArgs e)
        {
            HeaderTitle.Text = "Home";
            //listViewMainDishes.ItemsSource = lvmm.offers;
            ChangeListView(null);

            NavBarMinimize();

            //AnimatieNavBarOut();
            AnimateImageButton(AddNewItemButton, 0, 120, 800);

        }

        private void ImageButton_Clicked_Lists(object sender, EventArgs e)
        {
            HeaderTitle.Text = "My Lists";
            NavBarMinimize();

            ChangeListView(listViewMainLists);
            AnimateImageButton(AddNewItemButton, 0, 0, 800);
            BindingContext = lvm;

            AddNewItemButton.Command = GoToNewListPageCommand;



        }

        private void ImageButton_Clicked_Dishes(object sender, EventArgs e)
        {
            HeaderTitle.Text = "Dishes";

         
            NavBarMinimize();
            ChangeListView(listViewMainDishes);
            AnimateImageButton(AddNewItemButton,0,120,800);
            BindingContext = dvm;


        }

        private void ImageButton_Clicked_SpeacialItems(object sender, EventArgs e)
        {
            HeaderTitle.Text = "Offer Agent";

            AddNewItemButton.Command = GoToSpecialItemListCommand;
            AnimateImageButton(AddNewItemButton, 0,0, 800);
            BindingContext = sovm;

            NavBarMinimize();

            ChangeListView(listViewMainSpecialOffers);

           



        }
        private void navButton_Clicked(object sender, EventArgs e)
        {
            NavBarExpand();
        }

        private void Something1_Clicked(object sender, EventArgs e)
        {


        }

        private void Something2_Clicked(object sender, EventArgs e)
        {


        }

        private void LogOut_Clicked(object sender, EventArgs e)
        {


        }


        void ChangeListView(ListView lw)
        {
            if (currentListView != null)
                currentListView.IsVisible = false;
            if (lw != null)
            {
                lw.IsVisible = true;
                currentListView = lw;
            }
        }

        private void listViewMainDishes_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            Dish dish = e.Item as Dish;          

            Navigation.PushAsync(new DishView(dish));

            if (sender is ListView lv) lv.SelectedItem = null;

        }

        private void listViewMainSpecialOffers_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            SpecialOffer so = e.Item as SpecialOffer;

          

            if (sender is ListView lv) lv.SelectedItem = null;
        }
 /*-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                                                                                        ANIMATION STUFF
  ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        void ScaleButtonsDownAnimation()
        {
            house.ScaleTo(0, 400, easing: Easing.CubicOut);
            list.ScaleTo(0, 400, easing: Easing.CubicOut);
            bestik.ScaleTo(0, 400, easing: Easing.CubicOut);
            search.ScaleTo(0, 400, easing: Easing.CubicOut);

        }

        void ScaleButtonsUpAnimation()
        {
            house.ScaleTo(1, 400, easing: Easing.CubicInOut);
                           
            list.ScaleTo(1, 650, easing: Easing.CubicInOut);
                   
            bestik.ScaleTo(1, 900, easing: Easing.CubicInOut);
                 
            search.ScaleTo(1, 1050, easing: Easing.CubicInOut);
               
        }


        void NavBarMinimize()
        {
            ScaleButtonsDownAnimation();

            Device.StartTimer(TimeSpan.FromMilliseconds(400), () =>
            {
                AnimateNavBarOut();              
                AnimateImageButton(navButton, 0, 0, 1000);
                return false;
            });




        }


        void NavBarExpand()
        {

            AnimateImageButton(navButton, 0, -120, 500);

            AnimateNavBarIn();

        }




        void AnimateButton(Button b, int x, int y, int speed)
        {
            b.TranslateTo(x, y, (uint)speed, Easing.CubicOut);
        }


        void AnimateImageButton(ImageButton b, int x, int y, int speed)
        {
            b.TranslateTo(x, y, (uint)speed, Easing.CubicOut);
        }

        double navWidth = 0.2;
        void AnimateNavBarOut()
        {          
            MainGrid.ColumnDefinitions[1].Width = new GridLength(navWidth, GridUnitType.Star);

            Device.StartTimer(TimeSpan.FromMilliseconds(5), () =>
            {
                navWidth -= 0.03;
                if (navWidth <= 0)
                    navWidth = 0;
                MainGrid.ColumnDefinitions[1].Width = new GridLength(navWidth, GridUnitType.Star);
                if (navWidth == 0)
                {
                    return false;
                }
                return true;
                
            });
          

        }

        void AnimateNavBarIn()
        {
            MainGrid.ColumnDefinitions[1].Width = new GridLength(navWidth, GridUnitType.Star);

            Device.StartTimer(TimeSpan.FromMilliseconds(10), () =>
            {
                navWidth += 0.03;
                if (navWidth >= 0.2)
                    navWidth = 0.2;

                MainGrid.ColumnDefinitions[1].Width = new GridLength(navWidth, GridUnitType.Star);
                if (navWidth == 0.2)
                {
                    ScaleButtonsUpAnimation();
                    return false;

                }

                return true;

            });


        }


    }
}
