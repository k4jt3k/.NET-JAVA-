package org.example;

import static org.junit.jupiter.api.Assertions.*;
import org.junit.jupiter.api.Test;

class ProblemTest {
    //czy jak jeden przemdiot spelnia to zwroci co najmniej jeden element
    @Test
    public void testAtLeastOneItemFits(){
        Problem problem = new Problem(10,1,1,10);
        Result results = problem.Solve(10);

        assertFalse(results.itemsInKnapsack.isEmpty());
    }

    // czy jak zaden nie spelnia to czy bedzie puste
    @Test
    public void testNoItemsFits(){
        Problem problem = new Problem(5,1,10,20);
        Result result = problem.Solve(5);

        assertTrue(result.itemsInKnapsack.isEmpty());
        assertEquals(0, result.totalWeight);
        assertEquals(0, result.totalValue);
    }

    // czy waga i wartosc mieszcza sie w przedziale
    @Test
    public void testsItems(){
        int lowerBound = 1;
        int upperBound = 10;
        Problem problem = new Problem(100,1,lowerBound,upperBound);

        for (Item item : problem.items){
            assertTrue(item.weight >= lowerBound && item.weight <= upperBound, "Waga poza przedziałem!");
            assertTrue(item.value >= lowerBound && item.value <= upperBound, "Wartość poza przedziałem!");
        }
    }

    // sprawdzanie poprawnosci wyniku
    @Test
    public void testResult() {
        Problem problem = new Problem(10, 1, 1, 10);
        Result result = problem.Solve(15);

        assertEquals(15, result.totalWeight, "Waga końcowa powinna wynosić 15");
        assertEquals(25, result.totalValue, "Wartość końcowa powinna wynosić 25");
    }
}