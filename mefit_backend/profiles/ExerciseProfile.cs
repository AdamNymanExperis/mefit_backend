using AutoMapper;
using mefit_backend.models.domain;
using mefit_backend.models.DTO.ExerciseDtos;

namespace mefit_backend.Profiles
{
    public class ExerciseProfile : AutoMapper.Profile
    {
        public ExerciseProfile() {

            CreateMap<PostExerciseDTO, Exercise>();
            CreateMap<PutExerciseDTO, Exercise>();
            CreateMap<Exercise, GetExerciseDTO>()
            .ForMember(dto => dto.WorkoutExercise, options =>
                options.MapFrom(workoutExerciseDomain => workoutExerciseDomain.WorkoutExercise.Select(WorkoutExercise => $"api/v1/goal/{WorkoutExercise.Id}").ToList()))
                .ForMember(dto => dto.Impairments, options =>
                options.MapFrom(impairmentDomain => impairmentDomain.Impairments.Select(impairment => $"api/v1/impairment/{impairment.Id}").ToList()));
        }
    }
}
