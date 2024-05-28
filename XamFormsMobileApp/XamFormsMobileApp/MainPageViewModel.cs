using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using XamFormsMobileApp.Services;

namespace XamFormsMobileApp
{
    public class MainPageViewModel : BaseViewModel
    {
        public List<string> ColorNames = new List<string>();



        public RelayCommand SaveCommand => new RelayCommand(SaveClick);

        private async void SaveClick()
        {
            if (String.IsNullOrEmpty(Notes))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Notes field cannot be empty !", "ok");
                return;
            }

            NoteService noteService = new NoteService();
            noteService.Add(new Model.NotesModel() { Notes = Notes ,TextColor=SelectedTextColor});
            Notes = String.Empty;
        }


        public RelayCommand GoToNotesCommand => new RelayCommand(GoToNotesClick);

        private void GoToNotesClick()
        {
            App.Current.MainPage.Navigation.PushAsync(new NotesListPage());
        }
        public RelayCommand SetTextColorCommmand => new RelayCommand(SetTextColorClick);

        private async void SetTextColorClick()
        {
            var result =await App.Current.MainPage.DisplayActionSheet("Select Color", "cancel", null, ColorNames.ToArray());
            if (result=="cancel")
            {
                return;
            }
            SelectedTextColor = result;
        }
        


        public void Initilize()
        {
            ColorNames.Clear();

            foreach (var field in typeof(Xamarin.Forms.Color).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                if (field != null && !String.IsNullOrEmpty(field.Name))
                    ColorNames.Add(field.Name);
            }
            SelectedTextColor = "Black";

            Notes = @"
This section provides a guide on some of the more common things tasks or concepts that developers need to be aware of when developing Android applications.
Accessibility

This page describes how to use the Android Accessibility APIs to build apps according to the accessibility checklist.
Understanding Android API Levels

This guide describes how Android uses API levels to manage app compatibility across different versions of Android, and it explains how to configure Xamarin.Android project settings to deploy these API levels in your app. In addition, this guide explains how to write runtime code that deals with different API levels, and it provides a reference list of all Android API levels, version numbers(such as Android 8.0), Android code names(such as Oreo), and build version codes.
Resources in Android

This article introduces the concept of Android resources in Xamarin.Android and documents how to use them.It covers how to use resources in your Android application to support application localization, and multiple devices including varying screen sizes and densities.
Activity Lifecycle

Activities are a fundamental building block of Android Applications and they can exist in a number of different states.The activity lifecycle begins with instantiation and ends with destruction, and includes many states in between.When an activity changes state, the appropriate lifecycle event method is called, notifying the activity of the impending state change and allowing it to execute code to adapt to that change. This article examines the lifecycle of activities and explains the responsibility that an activity has during each of these state changes to be part of a well-behaved, reliable application.
Localization

This article explains how to localize a Xamarin.Android into other languages by translating strings and providing alternate images.
Services

This article covers Android services, which are Android components that allow work to be done in the background. It explains the different scenarios that services are suited for and shows how to implement them both for performing long-running background tasks as well as to provide an interface for remote procedure calls.
Broadcast Receivers

This guide covers how to create and use broadcast receivers, an Android component that responds to system-wide broadcasts, in Xamarin.Android.
Permissions

You can use the tooling support built into Visual Studio for Mac or Visual Studio to create and add permissions to the Android Manifest.This document describes how to add permissions in Visual Studio and Xamarin Studio.
Graphics and Animation yoo";

        }
    }
}
