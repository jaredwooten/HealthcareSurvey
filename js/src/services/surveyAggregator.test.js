const PatientSurvey = require('../models/patientSurvey');
const SurveyCategory = require('../models/surveyCategory');
const SurveyAggregator = require('./surveyAggregator');

describe('SurveyAggregator', () => {

    test('CalculateOverallScore_AllCategoriesRated_ReturnsWeightedAverage', () => {
        const survey = new PatientSurvey('Patient123');
        survey.setRating(SurveyCategory.StaffCourtesy, 5);
        survey.setRating(SurveyCategory.WaitTimes, 4);
        survey.setRating(SurveyCategory.FacilityCleanliness, 3);
        
        const aggregator = new SurveyAggregator(survey);
        const result = aggregator.calculateOverallScore();
        
        // Weighted: (5*0.3 + 4*0.3 + 3*0.4) / (0.3 + 0.3 + 0.4) = 3.9 / 1.0 = 3.9
        expect(result).toBeCloseTo(3.9, 10);
    });

    test('CalculateOverallScore_MissingCategory_RedistributesWeights', () => {
        const survey = new PatientSurvey('Patient456');
        survey.setRating(SurveyCategory.StaffCourtesy, 5);
        survey.setRating(SurveyCategory.WaitTimes, 4);
        // FacilityCleanliness is not rated (should be excluded from calculation)
        
        const aggregator = new SurveyAggregator(survey);
        const result = aggregator.calculateOverallScore();
        
        // When a category is missing, we redistribute weights proportionally
        // Active weights: StaffCourtesy(0.3) + WaitTimes(0.3) = 0.6 total
        // Redistributed: (5*0.3 + 4*0.3) / 0.6 = 2.7 / 0.6 = 4.5
        expect(result).toBeCloseTo(4.5, 10);
    });

    test('GetRatingSummary_OnlyShowsOldCategories', () => {
        const survey = new PatientSurvey('PatientSummary');
        survey.setRating(SurveyCategory.StaffCourtesy, 5);
        survey.setRating(SurveyCategory.WaitTimes, 4);
        survey.setRating(SurveyCategory.FacilityCleanliness, 3);
        
        const aggregator = new SurveyAggregator(survey);
        const summary = aggregator.getRatingSummary();
        
        expect(summary).toContain('Staff: 5');
        expect(summary).toContain('Wait: 4');
        expect(summary).toContain('Facility: 3');
    });
});