﻿namespace mefit_backend.Models.DTO.ProfileDtos
{
    public class PutProfileDTO
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string keycloakId { get; set; }

        // relationships
        //public int UserId { get; set; }
        public int AddressId { get; set; }
    }
}
