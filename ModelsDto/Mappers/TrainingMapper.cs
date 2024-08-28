using Stunt.Models;
using Stunt.ModelsDto;

public static class TrainingMapper
{
    public static TrainingDto ToDTO(Training training)
    {
        if (training == null)
        {
            return null;
        }

        var trainingDto = new TrainingDto
        {
            IdTraining = training.IdTraining,
            IdLocation = training.IdLocation,
            DateTime = training.DateTime,
            Description = training.Description,
            IdStuntLeader = training.IdStuntLeader,
            TrainingTypes = training.TrainingTypes?.Select(tt => new TrainingTypeMappingDto
            {
                TrainingId = tt.TrainingId,
                TrainingType = tt.TrainingType
            }).ToList() ?? new List<TrainingTypeMappingDto>(),
            Stuntmen = training.Stuntmans?.Select(sm => new StuntmanDto
            {
                IdPerson = sm.IdPerson,
                Name = sm.Name,
                Surname = sm.Surname,
                Birthdate = sm.Birthdate,
                Alias = sm.Alias,
                JoiningDate = sm.JoiningDate,
                Salary = sm.Salary,
                Rank = sm.Rank
            }).ToList() ?? new List<StuntmanDto>(),
            Horses = training.Horses?.Select(h => new HorseDto
            {
                IdHorse = h.IdHorse,
                Name = h.Name,
                Birthdate = h.Birthdate,
                Status = h.Status,
            }).ToList() ?? new List<HorseDto>()
        };

        if (training is ExamTraining examTraining)
        {
            return new ExamTrainingDto
            {
                IdTraining = examTraining.IdTraining,
                IdLocation = examTraining.IdLocation,
                DateTime = examTraining.DateTime,
                Description = examTraining.Description,
                IdStuntLeader = examTraining.IdStuntLeader,
                TrainingTypes = examTraining.TrainingTypes?.Select(tt => new TrainingTypeMappingDto
                {
                    TrainingId = tt.TrainingId,
                    TrainingType = tt.TrainingType
                }).ToList() ?? new List<TrainingTypeMappingDto>(),
                ExaminerLicence = examTraining.ExaminerLicence,
                Stuntmen = examTraining.Stuntmans?.Select(sm => new StuntmanDto
                {
                    IdPerson = sm.IdPerson,
                    Name = sm.Name,
                    Surname = sm.Surname,
                    Birthdate = sm.Birthdate,
                    Alias = sm.Alias,
                    JoiningDate = sm.JoiningDate,
                    Salary = sm.Salary,
                    Rank = sm.Rank
                }).ToList() ?? new List<StuntmanDto>(),
                Horses = examTraining.Horses?.Select(h => new HorseDto
                {
                    IdHorse = h.IdHorse,
                    Name = h.Name,
                    Birthdate = h.Birthdate,
                    Status = h.Status,
                }).ToList() ?? new List<HorseDto>()
            };
        }

        if (training is GroupTraining groupTraining)
        {
            return new GroupTrainingDto
            {
                IdTraining = groupTraining.IdTraining,
                IdLocation = groupTraining.IdLocation,
                DateTime = groupTraining.DateTime,
                Description = groupTraining.Description,
                IdStuntLeader = groupTraining.IdStuntLeader,
                TrainingTypes = groupTraining.TrainingTypes?.Select(tt => new TrainingTypeMappingDto
                {
                    TrainingId = tt.TrainingId,
                    TrainingType = tt.TrainingType
                }).ToList() ?? new List<TrainingTypeMappingDto>(),
                Difficulty = groupTraining.Difficulty,
                Stuntmen = groupTraining.Stuntmans?.Select(sm => new StuntmanDto
                {
                    IdPerson = sm.IdPerson,
                    Name = sm.Name,
                    Surname = sm.Surname,
                    Birthdate = sm.Birthdate,
                    Alias = sm.Alias,
                    JoiningDate = sm.JoiningDate,
                    Salary = sm.Salary,
                    Rank = sm.Rank
                }).ToList() ?? new List<StuntmanDto>(),
                Horses = groupTraining.Horses?.Select(h => new HorseDto
                {
                    IdHorse = h.IdHorse,
                    Name = h.Name,
                    Birthdate = h.Birthdate,
                    Status = h.Status,
                }).ToList() ?? new List<HorseDto>()
            };
        }

        return trainingDto;
    }

    public static Training ToEntity(TrainingDto trainingDto)
    {
        if (trainingDto == null)
        {
            return null;
        }

        var training = new Training
        {
            IdTraining = trainingDto.IdTraining,
            IdLocation = trainingDto.IdLocation,
            DateTime = trainingDto.DateTime,
            Description = trainingDto.Description,
            IdStuntLeader = trainingDto.IdStuntLeader,
            TrainingTypes = trainingDto.TrainingTypes?.Select(tt => new TrainingTypeMapping
            {
                TrainingId = tt.TrainingId,
                TrainingType = tt.TrainingType
            }).ToList() ?? new List<TrainingTypeMapping>(),
            Stuntmans = trainingDto.Stuntmen?.Select(sm => new Stuntman
            {
                IdPerson = sm.IdPerson,
                Name = sm.Name,
                Surname = sm.Surname,
                Birthdate = sm.Birthdate,
                Alias = sm.Alias,
                JoiningDate = sm.JoiningDate,
                Salary = sm.Salary,
                Rank = sm.Rank
            }).ToList() ?? new List<Stuntman>(),
            Horses = trainingDto.Horses?.Select(h => new Horse
            {
                IdHorse = h.IdHorse,
                Name = h.Name,
                Birthdate = h.Birthdate,
                Status = h.Status,
            }).ToList() ?? new List<Horse>()
        };

        if (trainingDto is ExamTrainingDto examTrainingDto)
        {
            return new ExamTraining
            {
                IdTraining = examTrainingDto.IdTraining,
                IdLocation = examTrainingDto.IdLocation,
                DateTime = examTrainingDto.DateTime,
                Description = examTrainingDto.Description,
                IdStuntLeader = examTrainingDto.IdStuntLeader,
                TrainingTypes = examTrainingDto.TrainingTypes?.Select(tt => new TrainingTypeMapping
                {
                    TrainingId = tt.TrainingId,
                    TrainingType = tt.TrainingType
                }).ToList() ?? new List<TrainingTypeMapping>(),
                ExaminerLicence = examTrainingDto.ExaminerLicence,
                Stuntmans = examTrainingDto.Stuntmen?.Select(sm => new Stuntman
                {
                    IdPerson = sm.IdPerson,
                    Name = sm.Name,
                    Surname = sm.Surname,
                    Birthdate = sm.Birthdate,
                    Alias = sm.Alias,
                    JoiningDate = sm.JoiningDate,
                    Salary = sm.Salary,
                    Rank = sm.Rank
                }).ToList() ?? new List<Stuntman>(),
                Horses = examTrainingDto.Horses?.Select(h => new Horse
                {
                    IdHorse = h.IdHorse,
                    Name = h.Name,
                    Birthdate = h.Birthdate,
                    Status = h.Status,
                }).ToList() ?? new List<Horse>()
            };
        }

        if (trainingDto is GroupTrainingDto groupTrainingDto)
        {
            return new GroupTraining
            {
                IdTraining = groupTrainingDto.IdTraining,
                IdLocation = groupTrainingDto.IdLocation,
                DateTime = groupTrainingDto.DateTime,
                Description = groupTrainingDto.Description,
                IdStuntLeader = groupTrainingDto.IdStuntLeader,
                TrainingTypes = groupTrainingDto.TrainingTypes?.Select(tt => new TrainingTypeMapping
                {
                    TrainingId = tt.TrainingId,
                    TrainingType = tt.TrainingType
                }).ToList() ?? new List<TrainingTypeMapping>(),
                Difficulty = groupTrainingDto.Difficulty,
                Stuntmans = groupTrainingDto.Stuntmen?.Select(sm => new Stuntman
                {
                    IdPerson = sm.IdPerson,
                    Name = sm.Name,
                    Surname = sm.Surname,
                    Birthdate = sm.Birthdate,
                    Alias = sm.Alias,
                    JoiningDate = sm.JoiningDate,
                    Salary = sm.Salary,
                    Rank = sm.Rank
                }).ToList() ?? new List<Stuntman>(),
                Horses = groupTrainingDto.Horses?.Select(h => new Horse
                {
                    IdHorse = h.IdHorse,
                    Name = h.Name,
                    Birthdate = h.Birthdate,
                    Status = h.Status,
                }).ToList() ?? new List<Horse>()
            };
        }

        return training;
    }
}
