using System;
using System.ComponentModel.DataAnnotations;

namespace KJMemo.Models
{
    public class PageMessageViewModel
    {

        public PageMessageViewModel()
        {
        }


        public PageMessageViewModel(string title, string text, EMessageType type){
            Title = title;
            Text = text;
            Type = type;
        }

        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        public LinkModel Link { get; set; }

        private EMessageType _type { get; set; }

        public EMessageType Type
        {
            get
            {
                return _type;
            }
            set
            {

                this.BootstrapClass = value.ConvertToBootstrapAlertClass();
                this._type = value;
            }
        }

        public string BootstrapClass { get; private set; }



    }


    public class LinkModel
    {
        public Uri Uri { get; set; }
        public string Text { get; set; }
    }


    public static class PageMessageExtension
    {

        public static string ConvertToBootstrapAlertClass(this EMessageType e)
        {

            string bootstrap_class = "";

            switch (e)
            {
                case EMessageType.PRIMARY:
                    bootstrap_class = "alert-primary";
                    break;
                case EMessageType.INFO:
                    bootstrap_class = "alert-info";
                    break;
                case EMessageType.SUCCESS:
                    bootstrap_class = "alert-success";
                    break;
                case EMessageType.WARNING:
                    bootstrap_class = "alert-warning";
                    break;
                case EMessageType.DANGER:
                    bootstrap_class = "alert-danger";
                    break;
                case EMessageType.NONE:
                    break;
            }

            return bootstrap_class;
        }


    }

    public enum EMessageType
    {
        NONE = 0,
        PRIMARY,
        INFO,
        SUCCESS,
        WARNING,
        DANGER,
    }
}
