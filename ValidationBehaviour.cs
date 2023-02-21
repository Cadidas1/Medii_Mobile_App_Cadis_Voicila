using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medii_Mobile_App_Cadis_Voicila
{
        class ValidationBehaviour : Behavior<Editor>
        {
            protected override void OnAttachedTo(Editor entry)
            {
                entry.TextChanged += OnEntryTextChanged;
                base.OnAttachedTo(entry);
            }
            protected override void OnDetachingFrom(Editor entry)
            {
                entry.TextChanged -= OnEntryTextChanged;
                base.OnDetachingFrom(entry);
            }
            void OnEntryTextChanged(object sender, TextChangedEventArgs args)
            {
                ((Editor)sender).BackgroundColor =
                string.IsNullOrEmpty(args.NewTextValue) ? Color.FromRgba("#AA4A44") :
                Color.FromRgba("#FFFFFF");
            }
        }
}
