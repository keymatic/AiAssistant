﻿namespace Key.AiAssistant.Application.DTOs.Prompts
{
    public class PromptDto : DtoBase
    {
        public string Title { get; set; }
        public string[] Messages { get; set; }
    }
}
