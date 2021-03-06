using System;
using FluentValidation;
using NzbDrone.Core.Annotations;
using NzbDrone.Core.ThingiProvider;
using NzbDrone.Core.Validation;

namespace NzbDrone.Core.Indexers.Eztv
{
    public class EztvSettingsValidator : AbstractValidator<EztvSettings>
    {
        public EztvSettingsValidator()
        {
            RuleFor(c => c.BaseUrl).ValidRootUrl();
        }
    }

    public class EztvSettings : IProviderConfig
    {
        private static readonly EztvSettingsValidator Validator = new EztvSettingsValidator();

        public EztvSettings()
        {
            BaseUrl = "";
        }

        [FieldDefinition(0, Label = "Website URL", HelpText = "Enter to URL to an EZTV compatible RSS feed")]
        public String BaseUrl { get; set; }

        public NzbDroneValidationResult Validate()
        {
            return new NzbDroneValidationResult(Validator.Validate(this));
        }
    }
}