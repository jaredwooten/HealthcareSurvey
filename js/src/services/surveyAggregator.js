const SurveyCategory = require('../models/surveyCategory');

/**
 * Combines ratings from different categories into a single "experience score."
 */
class SurveyAggregator {
    /**
     * Creates a new survey aggregator
     * @param {import('../models/patientSurvey')} survey - The patient survey to analyze
     */
    constructor(survey) {
        this._survey = survey;
    }

    /**
     * Calculates the overall score based on ratings from different categories.
     * @returns {number} The overall weighted score
     */
    calculateOverallScore() {
        const staffCourtesyRating = this._survey.getRating(SurveyCategory.StaffCourtesy);
        const waitTimesRating = this._survey.getRating(SurveyCategory.WaitTimes);
        const facilityCleanlinessRating = this._survey.getRating(SurveyCategory.FacilityCleanliness);
        
        const staffCourtesyWeight = 0.3;
        const waitTimesWeight = 0.3;
        const facilityCleanWeight = 0.4;
        
        const weightedSum = 
            staffCourtesyRating * staffCourtesyWeight +
            waitTimesRating * waitTimesWeight +
            facilityCleanlinessRating * facilityCleanWeight;
            
        return weightedSum;
    }
}

module.exports = SurveyAggregator;