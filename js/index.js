const PatientSurvey = require('./src/models/patientSurvey');
const SurveyCategory = require('./src/models/surveyCategory');
const SurveyAggregator = require('./src/services/surveyAggregator');

// Example usage
const survey = new PatientSurvey('ExamplePatient');
survey.setRating(SurveyCategory.StaffCourtesy, 5);
survey.setRating(SurveyCategory.WaitTimes, 4);
survey.setRating(SurveyCategory.FacilityCleanliness, 3);

const aggregator = new SurveyAggregator(survey);
const overallScore = aggregator.calculateOverallScore();

console.log(`Patient ID: ${survey.patientId}`);
console.log(`Staff Courtesy Rating: ${survey.getRating(SurveyCategory.StaffCourtesy)}`);
console.log(`Wait Times Rating: ${survey.getRating(SurveyCategory.WaitTimes)}`);
console.log(`Facility Cleanliness Rating: ${survey.getRating(SurveyCategory.FacilityCleanliness)}`);
console.log(`Overall Experience Score: ${overallScore}`);