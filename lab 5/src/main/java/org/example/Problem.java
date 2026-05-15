package org.example;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Problem {
    public int n;
    public int seed;
    public int lowerBound; //dolny zakres
    public int upperBound; //gorny zakres
    public List<Item> items;

    public Problem(int n, int seed, int lowerBound, int upperBound){
        this.n=n;
        this.seed=seed;
        this.lowerBound = lowerBound;
        this.upperBound = upperBound;
        this.items = new ArrayList<>();

        Random random = new Random(seed);

        for(int i=0; i<n;i++){
            int weight = random.nextInt(upperBound - lowerBound + 1) + lowerBound;
            int value = random.nextInt(upperBound - lowerBound + 1) + lowerBound;

            items.add(new Item(i,value,weight));
        }
    }

    @Override
    public String toString() {
        StringBuilder result = new StringBuilder();
        for (Item item : items) {
            result.append(item.toString()).append("\n");
        }
        return result.toString();
    }

// zadanie 2
    public Result Solve(int capacity) {
        Result result = new Result();

        List<Item> sortedItems = new ArrayList<>(this.items);

        sortedItems.sort((a, b) -> {
            double ratioA = (double) a.value / a.weight;
            double ratioB = (double) b.value / b.weight;
            return Double.compare(ratioB, ratioA); // sortowanie malejące
        });

        int currentCapacity = capacity;

        for (Item item : sortedItems) {
            while (item.weight <= currentCapacity) {
                result.itemsInKnapsack.add(item);
                result.totalWeight += item.weight;
                result.totalValue += item.value;
                currentCapacity -= item.weight;
            }
        }

        return result;
    }
}
