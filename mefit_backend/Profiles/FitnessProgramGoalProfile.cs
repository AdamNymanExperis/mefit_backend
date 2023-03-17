using mefit_backend.models.domain;
using mefit_backend.models.DTO.ExerciseDtos;
using mefit_backend.models.DTO.FitnessProgramGoalDtos;
using mefit_backend.models.DTO.WorkoutGoalDtos;
using mefit_backend.Models.dto.WorkoutExerciseDtos;
using Microsoft.Extensions.Options;

namespace mefit_backend.profiles
{
    public class FitnessProgramGoalProfile : AutoMapper.Profile
    {
        public FitnessProgramGoalProfile()
        {
            CreateMap<PostFitnessProgramGoalDTO, FitnessProgramGoal>();
            CreateMap<PutFitnessProgramGoalDTO, FitnessProgramGoal>();
            CreateMap<FitnessProgramGoal, GetFitnessProgramGoalDTO>()
                .ForMember(dto => dto.Goal, options =>
                options.MapFrom(goalDomain => $"api/v1/goal/{goalDomain.GoalId}"))
                .ForMember(dto => dto.FitnessProgram, options =>
                options.MapFrom(fitnessprogramDomain => $"api/v1/fitnessprogram/{fitnessprogramDomain.FitnessProgramId}"));

        }

    }
}
