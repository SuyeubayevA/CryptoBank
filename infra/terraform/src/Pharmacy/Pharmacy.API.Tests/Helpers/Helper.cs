using Bogus;

namespace Pharmacy.API.Tests.Helpers
{
    public static class Helper
    {
        public static Faker<T> GetFaker<T>() where T : class
        {
            return new Faker<T>()
                .RuleForType(typeof(int), faker => faker.Random.Int(1, 1000))
                .RuleForType(typeof(string), faker => faker.Company.CompanyName())
                .RuleForType(typeof(Guid), faker => Guid.NewGuid())
                .RuleForType(typeof(decimal), faker => faker.Random.Decimal())
                .RuleForType(typeof(double), faker => faker.Random.Double())
                .RuleForType(typeof(DateTime), faker => faker.Date.Past())
                .RuleForType(typeof(int?), faker => faker.Random.Int().OrNull(faker, 0f))
                .RuleForType(typeof(Guid?), faker => Guid.NewGuid().OrNull(faker, 0f))
                .RuleForType(typeof(decimal?), faker => faker.Random.Decimal().OrNull(faker, 0f))
                .RuleForType(typeof(double?), faker => faker.Random.Double().OrNull(faker, 0f))
                .RuleForType(typeof(DateTime?), faker => faker.Date.Past().OrNull(faker, 0f));
        }
    }
}
