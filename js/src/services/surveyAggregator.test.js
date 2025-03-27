const PatientSurvey = require('../models/patientSurvey');
const SurveyCategory = require('../models/surveyCategory');
const SurveyAggregator = require('./surveyAggregator');

describe('SurveyAggregator', () => {

    test('CalculateOverallScore_BasicScenario_ReturnsExpectedScore', () => {

        const survey = new PatientSurvey('PatientA');
        survey.setRating(SurveyCategory.StaffCourtesy, 5);
        survey.setRating(SurveyCategory.WaitTimes, 3);
        survey.setRating(SurveyCategory.FacilityCleanliness, 4);
        
        const aggregator = new SurveyAggregator(survey);
        const result = aggregator.calculateOverallScore();
        
        expect(result).toBe(4.0);
    });

    test('CalculateOverallScore_VariedRatings_ReturnsExpectedScore', () => {

        const survey = new PatientSurvey('PatientB');
        survey.setRating(SurveyCategory.StaffCourtesy, 2);
        survey.setRating(SurveyCategory.WaitTimes, 4);
        survey.setRating(SurveyCategory.FacilityCleanliness, 3);
        
        const aggregator = new SurveyAggregator(survey);
        const result = aggregator.calculateOverallScore();
        
        expect(result).toBe(3.0);
    });

    test('CalculateOverallScore_NoRatingForCategory_ReturnsExpectedScore', () => {

        const survey = new PatientSurvey('PatientC');
        survey.setRating(SurveyCategory.StaffCourtesy, 5);
        survey.setRating(SurveyCategory.WaitTimes, 4);
        
        const aggregator = new SurveyAggregator(survey);
        const result = aggregator.calculateOverallScore();
        
        expect(result).toBe(4.5);
    });
});