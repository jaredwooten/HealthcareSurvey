# Healthcare Survey Exercise

This coding exercise focuses on a patient satisfaction survey system for healthcare facilities.

In this exercise, you will do pair programming with another software engineer. They will take on the role of a less experienced engineer on your team.

In the pair programming paradigm, there are two roles: Driver and Navigator (see [this resource](https://www.industriallogic.com/pages/cheat-sheets/pdfs/Ensemble%20Programming%20Cheat%20Sheet.pdf)). You will be the *Navigator* and your pair engineer will be the *Driver*.

## Objectives

- Demonstrate effective communication about technical ideas
- Demonstrate technical expertise
- Use tests to drive new behavior
- Keep existing tests passing
- Code uses clean architecture and patterns

## Part 1: Fix the Failing Test

The current implementation of the survey aggregator has a failing test. Surveys that contain categories without scores should not be included in the aggregate score. Review and fix the weighting calculation to ensure proper score aggregation.

## Part 2: Add New Survey Categories

Extend the survey system by adding three new categories to measure additional aspects of the patient experience:

1. **Treatment Effectiveness** - How well the prescribed treatment addressed the patient's condition
2. **Communication Clarity** - How clearly healthcare providers explained diagnoses, treatments, and follow-up care
3. **Care Coordination** - How well different departments and healthcare providers worked together
