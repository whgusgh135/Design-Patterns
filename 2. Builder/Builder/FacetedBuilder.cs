namespace Builder
{
    public class FacetedPerson
    {
        // address
        public string StreetAddress, Postcode, City;

        // employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(Postcode)}: {Postcode}, {nameof(City)}: {City}, {nameof(CompanyName)}: {CompanyName}, {nameof(Position)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class FacetedPersonBuilder // facade
    {
        // reference!
        protected FacetedPerson facetedPerson = new FacetedPerson();

        public FacetedPersonJobBuilder Works => new FacetedPersonJobBuilder(facetedPerson);
        public FacetedPersonAddressBuilder Lives => new FacetedPersonAddressBuilder(facetedPerson);

        public static implicit operator FacetedPerson(FacetedPersonBuilder pb)
        {
            return pb.facetedPerson;
        }
    }

    public class FacetedPersonJobBuilder : FacetedPersonBuilder
    {
        public FacetedPersonJobBuilder(FacetedPerson facetedPerson)
        {
            this.facetedPerson = facetedPerson;
        }

        public FacetedPersonJobBuilder At(string companyName)
        {
            facetedPerson.CompanyName = companyName;
            return this;
        }

        public FacetedPersonJobBuilder AsA(string position)
        {
            facetedPerson.Position = position;
            return this;
        }

        public FacetedPersonJobBuilder Earning(int amount)
        {
            facetedPerson.AnnualIncome = amount;
            return this;
        }
    }

    public class FacetedPersonAddressBuilder : FacetedPersonBuilder
    {
        public FacetedPersonAddressBuilder(FacetedPerson facetedPerson)
        {
            this.facetedPerson = facetedPerson;
        }

        public FacetedPersonAddressBuilder At(string streetAddress)
        {
            facetedPerson.StreetAddress = streetAddress;
            return this;
        }
        
        public FacetedPersonAddressBuilder WithPostcode(string postcode)
        {
            facetedPerson.Postcode = postcode;
            return this;
        }
        
        public FacetedPersonAddressBuilder In(string city)
        {
            facetedPerson.City = city;
            return this;
        }
    }
}