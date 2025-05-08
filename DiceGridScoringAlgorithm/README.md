# 2D Dice Grid Scoring Algorithm

[Original Python version](https://www.101computing.net/2d-dice-grid-scoring-algorithm/)

This challenge is based on a 4×4 grid of dice (16 dice in total). Each game starts by shaking the grid to generate a new grid of 16 values.

All dice are 6-sided dice, generating random values between 1 and 6 when the grid is shaken. The grid can be simplified by showing the actual dice values:

![example of the grid](https://www.101computing.net/wp/wp-content/uploads/2D-dice-grid-values.png)

Once the new grid is set, its score can be calculated by identifying specific patterns as follows:
- Start with a score of 0,
- If all four corners are even numbers, add 20 pts to the score,
- If all four corners are odd numbers, add 20 pts to the score,
- If all four dice on a diagonal are even numbers, add 20 pts to the score,
- If all four dice on a diagonal are odd numbers, add 20 pts to the score,
- If all four dice on on any row are even numbers, add 20 pts to the score,
- If all four dice on on any row are odd numbers, add 20 pts to the score,
- If all four dice on on any column are even numbers, add 20 pts to the score,
- If all four dice on on any column are odd numbers, add 20 pts to the score,
- Add to the score the total value (sum) of all 16 dice.