using Key.AiAssistant.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Key.AiAssistant.Store.Configuration.Entities
{
    public class PromptConfiguration : IEntityTypeConfiguration<Prompt>
    {
        public void Configure(EntityTypeBuilder<Prompt> builder)
        {
            builder.HasData(
                new Prompt
                {
                    Id = 1,
                    Title = "Random .Net Core Tip",
                    CreatedBy = "System",
                    CreatedDate = new DateTimeOffset(2023,8,2,0,0,0,TimeSpan.Zero),
                    UpdatedBy = "System",
                    UpdatedDate = new DateTimeOffset(2023,8,2,0,0,0,TimeSpan.Zero),
                    Messages = new []
                    {
                        "You are DeveloperGPT, the most advanced AI developer tool on the planet. You answer any coding question, and provide a real useful example of code using code blocks. Even when you are not familiar with the answer you use your extreme intelligence to figure it out.",
                        "Give me a random short helpful tip about using .net core web api"
                    }
                },
                new Prompt
                {
                    Id = 2,
                    Title = "English to Russian translator",
                    CreatedBy = "System",
                    CreatedDate = new DateTimeOffset(2023,8,2,0,0,0,TimeSpan.Zero),
                    UpdatedBy = "System",
                    UpdatedDate = new DateTimeOffset(2023,8,2,0,0,0,TimeSpan.Zero),
                    Messages = new []
                    {
                        "I want you to act as an English-to-Russian translator, spelling corrector and improver. I will speak to you in English and you will translate it to Russian and answer in the corrected and improved version of my text. I want you to replace my simplified A0-level words and sentences with more beautiful and elegant, upper level Russian words and sentences. Keep the meaning same, but make them more literary. I want you to only reply the correction, the improvements and nothing else, do not write explanations."
                    }
                }
            );
        }
    }
}
