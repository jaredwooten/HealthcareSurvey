using HealthcareSurvey.Models;

namespace HealthcareSurvey.Tests.Models
{
    public class PatientSurveyTests
    {
        [Fact]
        public void Constructor_ShouldInitializeWithEmptyRatings()
        {
            // Arrange & Act
            var survey = new PatientSurvey("P123");

            // Assert
            Assert.Equal("P123", survey.PatientId);
            Assert.Empty(survey.CategoryRatings);
        }

        [Theory]
        [InlineData(3, 3)]
        [InlineData(0, 1)]  // Should clamp to minimum
        [InlineData(6, 5)]  // Should clamp to maximum
        public void SetRating_ShouldClampValuesBetweenOneAndFive(int input, int expected)
        {
            // Arrange
            var survey = new PatientSurvey("P123");

            // Act
            survey.SetRating(SurveyCategory.StaffCourtesy, input);

            // Assert
            Assert.Equal(expected, survey.GetRating(SurveyCategory.StaffCourtesy));
        }

        [Fact]
        public void GetRating_NonexistentCategory_ShouldReturnZero()
        {
            // Arrange
            var survey = new PatientSurvey("P123");

            // Act
            var rating = survey.GetRating(SurveyCategory.WaitTimes);

            // Assert
            Assert.Equal(0, rating);
        }

        [Fact]
        public void SetRating_ShouldUpdateExistingRating()
        {
            // Arrange
            var survey = new PatientSurvey("P123");
            survey.SetRating(SurveyCategory.FacilityCleanliness, 3);

            // Act
            survey.SetRating(SurveyCategory.FacilityCleanliness, 4);

            // Assert
            Assert.Equal(4, survey.GetRating(SurveyCategory.FacilityCleanliness));
        }
    }
}