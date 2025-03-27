/**
 * Represents a patient satisfaction survey
 */
class PatientSurvey {
    /**
     * Creates a new patient survey
     * @param {string} patientId - The ID of the patient
     */
    constructor(patientId) {
        this.patientId = patientId;
        /**
         * Ratings for each category (e.g., Staff Courtesy, Wait Times, Facility Cleanliness).
         * Values typically range from 1 to 5.
         * @type {Object.<number, number>}
         */
        this.categoryRatings = {};
    }

    /**
     * Sets a rating for a specific category
     * @param {number} category - The category enum value
     * @param {number} rating - The rating value (1-5)
     */
    setRating(category, rating) {
        if (rating < 1) rating = 1;
        if (rating > 5) rating = 5;
        this.categoryRatings[category] = rating;
    }

    /**
     * Gets the rating for a specific category
     * @param {number} category - The category enum value
     * @returns {number} The rating value, or 0 if not set
     */
    getRating(category) {
        return this.categoryRatings.hasOwnProperty(category) ? this.categoryRatings[category] : 0;
    }
}

module.exports = PatientSurvey;