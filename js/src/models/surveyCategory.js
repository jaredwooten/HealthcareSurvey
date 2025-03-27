/**
 * Enum for survey categories
 * @readonly
 * @enum {number}
 */
const SurveyCategory = {
    StaffCourtesy: 0,
    WaitTimes: 1,
    FacilityCleanliness: 2,
    
    // We might add more categories, e.g., BillingExperience, TelehealthQuality, etc.
    // Also, we want to allow dynamic weighting in the future.
};

module.exports = SurveyCategory;