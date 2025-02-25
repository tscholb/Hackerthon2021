﻿/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components;

namespace NUIKioskCafeteria
{
    public partial class OrderPage : ContentControlPage, INextPage
    {
        private CollectionView colView;

        public OrderPage()
        {
            InitializeComponent();
            InitializeCollectionList();

            BindingContext = OrderManager.Instance;
            totalPrice.SetBinding(TextLabel.TextProperty, "TotalPrice");
        }

        public void InitializeCollectionList()
        {

            colView = new CollectionView()
            {
                HideScrollbar = false,

                ItemsSource = OrderManager.Instance.GallerySource,
                ItemsLayouter = new LinearLayouter(),
                ItemTemplate = new DataTemplate(() =>
                {
                    var item = new DefaultOrdertem();
                    item.NameLabel.SetBinding(TextLabel.TextProperty, "NameLabel");
                    item.PriceLabel.SetBinding(TextLabel.TextProperty, "PriceLabel");
                    item.Image.SetBinding(ImageView.ResourceUrlProperty, "ImageUrl");
                    return item;
                }),
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                SelectionMode = ItemSelectionMode.Single,
                Weight = 0.9f,
            };
            CollectionLayoutView.Add(colView);
        }

        public ContentPage NextPage()
        {
            return new PayPage();
        }

        protected override void NextPageClicked(object sender, ClickedEventArgs e)
        {
            if (CurrentIPage == null)
            {
                Tizen.Log.Error("NUI", "Push error, CurrentIPage is null");
                return;
            }
            Window.Instance.GetDefaultNavigator().Push(CurrentIPage.NextPage());
        }
    }
}
