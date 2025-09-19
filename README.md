# Healthcare Survey Exercise

This coding exercise focuses on a patient satisfaction survey system for healthcare facilities.

In this exercise, you will do pair programming with another software engineer. They will take on the role of a software engineer on your team.

In the pair programming paradigm, there are two roles: Driver and Navigator (see [this resource](https://www.industriallogic.com/pages/cheat-sheets/pdfs/Ensemble%20Programming%20Cheat%20Sheet.pdf)). You will be the *Navigator* and your pair engineer will be the *Driver*.

## Objectives

- Demonstrate effective communication about technical ideas
- Demonstrate technical expertise
- Use tests to drive new behavior, refactoring as necessary after each passing test
- Keep existing tests passing
- Use clean code and design patterns

## Part 1: Refactor the Existing Design

The current implementation of the survey aggregator has several code smells. Adding a new category requires changes in multiple places. Refactor the code to improve its design so that adding new categories in the future will require minimal changes.

## Part 2: Add New Survey Categories

Extend the survey system by adding support for two new categories that have been added to the survey system:

1. **Billing Experience** - How satisfied patients are with the billing process, clarity of charges, and insurance handling
2. **Telehealth Quality** - For remote consultations, how well the technology worked and the quality of the virtual care experience

These categories already exist in the `SurveyCategory` enum but are not yet supported by the `SurveyAggregator` class. The candidate should refactor the code to support all categories without requiring changes in multiple places when new categories are added in the future.

### Expected Category Weights

When all 5 categories are properly supported, the weights should be distributed as follows:

- **Staff Courtesy**: 25% (0.25)
- **Wait Times**: 20% (0.20) 
- **Facility Cleanliness**: 25% (0.25)
- **Billing Experience**: 15% (0.15)
- **Telehealth Quality**: 15% (0.15)

Currently, only the first 3 categories are used with weights of 30%, 30%, and 40% respectively. After the refactoring, a survey with ratings of [5, 4, 3, 2, 5] should yield an overall score of 3.8 instead of the current 3.9.
