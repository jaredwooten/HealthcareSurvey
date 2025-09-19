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
        
        let totalWeight = 0;
        let weightedSum = 0;
        
        if (staffCourtesyRating > 0) {
            weightedSum += staffCourtesyRating * staffCourtesyWeight;
            totalWeight += staffCourtesyWeight;
        }
        if (waitTimesRating > 0) {
            weightedSum += waitTimesRating * waitTimesWeight;
            totalWeight += waitTimesWeight;
        }
        if (facilityCleanlinessRating > 0) {
            weightedSum += facilityCleanlinessRating * facilityCleanWeight;
            totalWeight += facilityCleanWeight;
        }
        
        return Number((totalWeight > 0 ? weightedSum / totalWeight : 0).toFixed(2));
    }

    /**
     * Gets all the category weights
     * @returns {Object} Object with category weights
     */
    static getCategoryWeights() {
        return {
            [SurveyCategory.StaffCourtesy]: 0.3,
            [SurveyCategory.WaitTimes]: 0.3,
            [SurveyCategory.FacilityCleanliness]: 0.4
        };
    }

    /**
     * Gets a summary of all ratings
     * @returns {string} Summary of ratings
     */
    getRatingSummary() {
        const staff = this._survey.getRating(SurveyCategory.StaffCourtesy);
        const wait = this._survey.getRating(SurveyCategory.WaitTimes);
        const facility = this._survey.getRating(SurveyCategory.FacilityCleanliness);
        
        return `Staff: ${staff}, Wait: ${wait}, Facility: ${facility}`;
    }
}

module.exports = SurveyAggregator;