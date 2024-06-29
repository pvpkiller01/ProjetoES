namespace ESProjeto.Client.Services.CrewMemberServices
{
    public class CrewMember
    {

        public int id { get; set; }

        public string Name { get; set; }
        public string Biography { get; set; }
        public string Profile_Path { get; set; }
        public DateTime Birthday { get; set; }
        public string Place_Of_Birth { get; set; }
        public int Gender { get; set; }
        public string Known_For_Department { get; set; }

    }
}
