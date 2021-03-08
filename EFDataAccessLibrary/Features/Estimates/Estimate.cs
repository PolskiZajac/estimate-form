namespace EFDataAccessLibrary.Features.Estimates
{
    public sealed class Estimate
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        // TODO: change to enum
    }

    public sealed class EstimateDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
