# New Categories Specification

## New Categories

1. **Billing Experience** - How satisfied patients are with the billing process, clarity of charges, and insurance handling
2. **Telehealth Quality** - For remote consultations, how well the technology worked and the quality of the virtual care experience

### Expected Category Weights

When all 5 categories are properly supported, the weights should be distributed as follows:

- **Staff Courtesy**: 25% (0.25)
- **Wait Times**: 20% (0.20) 
- **Facility Cleanliness**: 25% (0.25)
- **Billing Experience**: 15% (0.15)
- **Telehealth Quality**: 15% (0.15)

Currently, only the first 3 categories are used with weights of 30%, 30%, and 40% respectively. After the refactoring, a survey with ratings of [5, 4, 3, 2, 5] should yield an overall score of 3.8 instead of the current 3.9.