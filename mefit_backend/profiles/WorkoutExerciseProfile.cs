using mefit_backend.models.domain;
using mefit_backend.models.DTO.ExerciseDtos;
using mefit_backend.Models.dto.WorkoutExerciseDtos;
using Microsoft.Extensions.Options;

namespace mefit_backend.profiles
{
    public class WorkoutExerciseProfile : AutoMapper.Profile
    {
        public WorkoutExerciseProfile()
        {
            CreateMap<PostWorkoutExerciseDTO, WorkoutExercise>();
            CreateMap<PutWorkoutExerciseDTO, WorkoutExercise>();
            CreateMap<WorkoutExercise, GetWorkoutExerciseDTO>()
                .ForMember(dto => dto.Exercise, options =>
                options.MapFrom(exerciseDomain => $"api/v1/exercise/{exerciseDomain.ExerciseId}"));

        }
        
    }
}
