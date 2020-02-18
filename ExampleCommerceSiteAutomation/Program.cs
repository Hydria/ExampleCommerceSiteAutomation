using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumPractice;
using System;

namespace ExampleCommerceSiteAutomation
{
    class Program
    {
        [SetUp]
        public void Initialise()
        {
            //initalise web browser
            PropertiesCollection.driver = new ChromeDriver();
            //navigate to commerce site homepage
            PropertiesCollection.driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            Console.WriteLine("Opened URL");
        }

        [Test]
        public void LinkTesting()
        {
            //page.TestLink("My Store")
            Methods Method = new Methods(); //initialises link tests
            Method.TestLinkID("contact-link", "http://automationpractice.com/index.php?controller=contact"); //Contact Us
            Method.TestLinkClass("header_user_info","http://automationpractice.com/index.php?controller=authentication&back=my-account"); //Sign In
            Method.TestLinkID("header_logo", "http://automationpractice.com/index.php"); //"Your Logo" Logo
            Method.TestLinkName("submit_search", "http://automationpractice.com/index.php?controller=search&orderby=position&orderway=desc&search_query=&submit_search="); //Press Search Button
            Method.TestLinkXPath("/html/body[@id='index']/div[@id='page']/div[@class='header-container']/header[@id='header']/div[3]/div[@class='container']/div[@class='row']/div[@class='col-sm-4 clearfix'][2]/div[@class='shopping_cart']/a", "http://automationpractice.com/index.php?controller=order"); //Press Shopping Cart (because bounding box is too big)"
            Method.TestLinkXPath("/html/body[@id='index']/div[@id='page']/div[@class='header-container']/header[@id='header']/div[3]/div[@class='container']/div[@class='row']/div[@id='block_top_menu']/ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li[1]/a[@class='sf-with-ul']", "http://automationpractice.com/index.php?id_category=3&controller=category"); //Presses Women Category
            Method.TestLinkXPath("/html/body[@id='index']/div[@id='page']/div[@class='header-container']/header[@id='header']/div[3]/div[@class='container']/div[@class='row']/div[@id='block_top_menu']/ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li[2]/a[@class='sf-with-ul']", "http://automationpractice.com/index.php?id_category=8&controller=category"); //Presses Dresses Category
            Method.TestLinkXPath("/html/body[@id='index']/div[@id='page']/div[@class='header-container']/header[@id='header']/div[3]/div[@class='container']/div[@class='row']/div[@id='block_top_menu']/ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li[3]/a", "http://automationpractice.com/index.php?id_category=5&controller=category"); //Presses T-Shirts Category
            //Method.TestLinkXPath("/html/body[@id='index']/div[@id='page']/div[@class='header-container']/header[@id='header']/div[3]/div[@class='container']/div[@class='row']/div[@id='block_top_menu']/ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li[@class='sfHover']/ul[@class='submenu-container clearfix first-in-line-xs']/li[@class='sfHover']/a[@class='sf-with-ul']", "http://automationpractice.com/index.php?id_category=4&controller=category", "/html/body[@id='index']/div[@id='page']/div[@class='header-container']/header[@id='header']/div[3]/div[@class='container']/div[@class='row']/div[@id='block_top_menu']/ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li[1]/a[@class='sf-with-ul']"); //Presses Tops in Women's category (currently broken)
            /*Method.TestLinkXPath("/html/body[@id='index']/div[@id='page']/div[@class='header-container']/header[@id='header']/div[3]/div[@class='container']/div[@class='row']/div[@id='block_top_menu']/ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li[@class='sfHover']/ul[@class='submenu-container clearfix first-in-line-xs']/li[@class='sfHover']/ul/li[1]/a", "http://automationpractice.com/index.php?id_category=5&controller=category"); //Presses T-shirts in women's category (broken, needs updating)
            Method.TestLinkXPath("/html/body[@id='index']/div[@id='page']/div[@class='header-container']/header[@id='header']/div[3]/div[@class='container']/div[@class='row']/div[@id='block_top_menu']/ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li[@class='sfHover']/ul[@class='submenu-container clearfix first-in-line-xs']/li[@class='sfHover']/ul/li[2]/a", "http://automationpractice.com/index.php?id_category=7&controller=category"); //Presses Blouses in women's category (broken, needs updating)
            Method.TestLinkXPath("/html/body[@id='index']/div[@id='page']/div[@class='header-container']/header[@id='header']/div[3]/div[@class='container']/div[@class='row']/div[@id='block_top_menu']/ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li[@class='sfHover']/ul[@class='submenu-container clearfix first-in-line-xs']/li[1]/a", "http://automationpractice.com/index.php?id_category=9&controller=category", "/html/body[@id='index']/div[@id='page']/div[@class='header-container']/header[@id='header']/div[3]/div[@class='container']/div[@class='row']/div[@id='block_top_menu']/ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li[@class='sfHover']/a[@class='sf-with-ul']"); //Presses Casual Dresses In Dresses (broken)
            Method.TestLinkXPath("/html/body[@id='index']/div[@id='page']/div[@class='header-container']/header[@id='header']/div[3]/div[@class='container']/div[@class='row']/div[@id='block_top_menu']/ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li[@class='sfHover']/ul[@class='submenu-container clearfix first-in-line-xs']/li[2]/a", "http://automationpractice.com/index.php?id_category=10&controller=category"); //Presses Evening Dresses In Dresses (broken)
            Method.TestLinkXPath("/html/body[@id='index']/div[@id='page']/div[@class='header-container']/header[@id='header']/div[3]/div[@class='container']/div[@class='row']/div[@id='block_top_menu']/ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li[@class='sfHover']/ul[@class='submenu-container clearfix first-in-line-xs']/li[3]/a", "http://automationpractice.com/index.php?id_category=11&controller=category"); //Presses Summer Dresses In Dresses (broken)*/
            //Method.TestLinkXPath("/html/body[@id='index']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@id='slider_row']/div[@id='top_column']/div[@id='homepage-slider']/div[@class='bx-wrapper']/div[@class='bx-viewport']/ul[@id='homeslider']/li[@class='homeslider-container'][3]/div[@class='homeslider-description']/p[2]/button[@class='btn btn-default']", "https://www.prestashop.com/en?utm_source=v16_homeslider"); //Presses Shop Now! button on the scrolling images
            //Method.TestLinkXPath ("//button[@class = 'btn btn-default']", "https://www.prestashop.com/en?utm_source=v16_homeslider"); //Presses Shop Now! button on the scrolling images (broken)
            //Method.TestLinkXPath("/html/body[@id='index']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@id='slider_row']/div[@id='top_column']/div[@id='htmlcontent_top']/ul[@class='htmlcontent-home clearfix row']/li[@class='htmlcontent-item-1 col-xs-4']/a[@class='item-link']/img[@class='item-img']/@src", "https://www.prestashop.com/en"); //test right upper image
            //Method.TestLinkXPath("/html/body[@id='index']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@id='slider_row']/div[@id='top_column']/div[@id='htmlcontent_top']/ul[@class='htmlcontent-home clearfix row']/li[@class='htmlcontent-item-2 col-xs-4']/a[@class='item-link']/img[@class='item-img']/@src", "https://www.prestashop.com/en"); //test right lower image
        }

        [Test]
        public void TestPurchase()
        {
            Methods Method = new Methods(); //initalises all the below tests
            Method.ClickXPath("/html/body[@id='index']/div[@id='page']/div[@class='header-container']/header[@id='header']/div[3]/div[@class='container']/div[@class='row']/div[@id='block_top_menu']/ul[@class='sf-menu clearfix menu-content sf-js-enabled sf-arrows']/li[1]/a[@class='sf-with-ul']"); //select women's category
            //Method.DropDownSelect("selectProductSort", "Product Name: A to Z"); //this part of the website doesn't actually funciton atm lmao
            Method.WaitForXPath("/html/body[@id='category']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/ul[@class='product_list grid row']/li[@class='ajax_block_product col-xs-12 col-sm-6 col-md-4 first-in-line first-item-of-tablet-line first-item-of-mobile-line']/div[@class='product-container']/div[@class='right-block']/div[@class='button-container']/a[@class='button ajax_add_to_cart_button btn btn-default']/span"); //wait for add to cart button to load
            Method.ClickXPath("/html/body[@id='category']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/ul[@class='product_list grid row']/li[@class='ajax_block_product col-xs-12 col-sm-6 col-md-4 first-in-line first-item-of-tablet-line first-item-of-mobile-line']/div[@class='product-container']/div[@class='right-block']/div[@class='button-container']/a[@class='button ajax_add_to_cart_button btn btn-default']/span"); //add first item to cart
            Method.WaitForXPath("/html/body[@id='category']/div[@id='page']/div[@class='header-container']/header[@id='header']/div[3]/div[@class='container']/div[@class='row']/div[@id='layer_cart']/div[@class='clearfix']/div[@class='layer_cart_cart col-xs-12 col-md-6']/div[@class='button-container']/a[@class='btn btn-default button button-medium']/span"); //wait for proceed to checkout button to load
            Method.ClickXPath("/html/body[@id='category']/div[@id='page']/div[@class='header-container']/header[@id='header']/div[3]/div[@class='container']/div[@class='row']/div[@id='layer_cart']/div[@class='clearfix']/div[@class='layer_cart_cart col-xs-12 col-md-6']/div[@class='button-container']/a[@class='btn btn-default button button-medium']/span"); //press proceed to checkout
            Method.WaitForXPath("/html/body[@id='order']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/p[@class='cart_navigation clearfix']/a[@class='button btn btn-default standard-checkout button-medium']/span"); //wait for proceed checkout button on new page to load
            Method.ClickXPath("/html/body[@id='order']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/p[@class='cart_navigation clearfix']/a[@class='button btn btn-default standard-checkout button-medium']/span"); //press proceed to checkout
            Method.EnterText("email", "craigbautomationtest@test.com"); //enter email info
            Method.EnterText("passwd", "automation"); //enter password
            Method.ClickID("SubmitLogin"); //press login button
            Method.CheckAddress("craig b", "autotest", "711 Louisiana St", "Houston, Texas 77002", "United States", "5553456357"); //check delivery address is correct
            Method.ClickXPath("/html/body[@id='order']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/form/p[@class='cart_navigation clearfix']/button[@class='button btn btn-default button-medium']/span"); //proceed to checkout
            Method.WaitForXPath("/html/body[@id='order']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/div[@id='carrier_area']/form[@id='form']/p[@class='cart_navigation clearfix']/button[@class='button btn btn-default standard-checkout button-medium']/span"); //check to see if proceed to checkout button is loaded (becuase loading the checkbox wasn't working)
            Method.ClickXPath("/html/body[@id='order']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/div[@id='carrier_area']/form[@id='form']/div[@class='order_carrier_content box']/p[@class='checkbox']/div[@id='uniform-cgv']/span/input[@id='cgv']"); //tick the checkbox and agree to those terms and conditions
            Method.ClickXPath("/html/body[@id='order']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/div[@id='carrier_area']/form[@id='form']/p[@class='cart_navigation clearfix']/button[@class='button btn btn-default standard-checkout button-medium']/span"); //Proceed to checkout
            Method.WaitForXPath("/html/body[@id='order']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/div[@class='paiement_block']/div[@id='HOOK_PAYMENT']/div[@class='row'][1]/div[@class='col-xs-12 col-md-6']/p[@class='payment_module']/a[@class='bankwire']"); //wait for bankwire option to be available
            Method.ClickXPath("/html/body[@id='order']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/div[@class='paiement_block']/div[@id='HOOK_PAYMENT']/div[@class='row'][1]/div[@class='col-xs-12 col-md-6']/p[@class='payment_module']/a[@class='bankwire']"); //purchase by bankwire (who uses cheques nowadays)
            Method.WaitForXPath("/html/body[@id='module-bankwire-payment']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/form/p[@id='cart_navigation']/button[@class='button btn btn-default button-medium']/span"); //wait for order to confirm
            Method.ClickXPath("/html/body[@id='module-bankwire-payment']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/form/p[@id='cart_navigation']/button[@class='button btn btn-default button-medium']/span"); //press confirm order
            Method.GetTextXPath("/html/body[@id='order-confirmation']/div[@id='page']/div[@class='columns-container']/div[@id='columns']/div[@class='row'][2]/div[@id='center_column']/div[@class='box']/p[@class='cheque-indent']/strong[@class='dark']", "Your order on My Store is complete."); //confirm that order was confirmed and order is now complete
            Console.WriteLine("Purchase Complete"); //test works
        }

        [TearDown]
        public void Cleanup()
        {   //closes browser after use
            PropertiesCollection.driver.Close();
            Console.WriteLine("Closed Browser");
        }
    }
}
