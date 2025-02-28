# Healthcare Survey Exercise

This coding exercise focuses on a patient satisfaction survey system for healthcare facilities.

## Part 1: Fix the Failing Test

The current implementation of `SurveyAggregator.CalculateOverallScore()` has a failing test. Surveys that contain categories without scores should not be included in the aggregate score. Review and fix the weighting calculation to ensure proper score aggregation.

## Part 2: Add New Survey Categories

Extend the survey system by adding three new categories to measure additional aspects of the patient experience:

1. **Treatment Effectiveness** - How well the prescribed treatment addressed the patient's condition
2. **Communication Clarity** - How clearly healthcare providers explained diagnoses, treatments, and follow-up care
3. **Care Coordination** - How well different departments and healthcare providers worked together

### Requirements

- Add the new categories to the `SurveyCategory` enum
- Update the `CalculateOverallScore()` method to include these new categories
- Determine appropriate weights for all categories (original + new)
- Update tests to verify the new calculation logic

## Success Criteria

- All tests pass
- Weights sum to exactly 1.0 (100%)
- Code maintains clean architecture and follows existing patterns
- New categories are meaningful and relevant to healthcare quality assessment