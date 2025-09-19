using HealthcareSurvey.Models;
using HealthcareSurvey.Services;

namespace HealthcareSurvey.Tests
{
    public class SurveyAggregatorTests
    {
        [Fact]
        public void CalculateOverallScore_AllCategoriesRated_ReturnsWeightedAverage()
        {
            var survey = new PatientSurvey("Patient123");
            survey.SetRating(SurveyCategory.StaffCourtesy, 5);
            survey.SetRating(SurveyCategory.WaitTimes, 4);
            survey.SetRating(SurveyCategory.FacilityCleanliness, 3);

            var aggregator = new SurveyAggregator(survey);

            var result = aggregator.CalculateOverallScore();

            // Weighted: (5*0.3 + 4*0.3 + 3*0.4) / (0.3 + 0.3 + 0.4) = 3.9 / 1.0 = 3.9
            Assert.Equal(3.9m, result);
        }

        [Fact]
        public void CalculateOverallScore_MissingCategory_RedistributesWeights()
        {
            var survey = new PatientSurvey("Patient456");
            survey.SetRating(SurveyCategory.StaffCourtesy, 5);
            survey.SetRating(SurveyCategory.WaitTimes, 4);
            // FacilityCleanliness is not rated (should be excluded from calculation)

            var aggregator = new SurveyAggregator(survey);

            var result = aggregator.CalculateOverallScore();

            // When a category is missing, we redistribute weights proportionally
            // Active weights: StaffCourtesy(0.3) + WaitTimes(0.3) = 0.6 total
            // Redistributed: (5*0.3 + 4*0.3) / 0.6 = 2.7 / 0.6 = 4.5
            Assert.Equal(4.5m, result);
        }

        [Fact]
        public void GetCategoryWeights_ReturnsCurrentWeights()
        {
            var weights = SurveyAggregator.GetCategoryWeights();

            Assert.Equal(0.3m, weights[SurveyCategory.StaffCourtesy]);
            Assert.Equal(0.3m, weights[SurveyCategory.WaitTimes]);
            Assert.Equal(0.4m, weights[SurveyCategory.FacilityCleanliness]);
            
            Assert.Equal(3, weights.Count);
        }

        [Fact]
        public void GetRatingSummary_OnlyShowsOldCategories()
        {
            var survey = new PatientSurvey("PatientSummary");
            survey.SetRating(SurveyCategory.StaffCourtesy, 5);
            survey.SetRating(SurveyCategory.WaitTimes, 4);
            survey.SetRating(SurveyCategory.FacilityCleanliness, 3);
            
            var aggregator = new SurveyAggregator(survey);
            var summary = aggregator.GetRatingSummary();

            Assert.Contains("Staff: 5", summary);
            Assert.Contains("Wait: 4", summary);
            Assert.Contains("Facility: 3", summary);
        }
    }
}