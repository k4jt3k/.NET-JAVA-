package org.example;

import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        int n = 10;
        int seed = 1;
        int capacity = 15;

        Problem problem = new Problem(n, seed, 1, 10);
        System.out.println("Pojemnosc:\n" + capacity);
        System.out.println(problem.toString());

        Result solution = problem.Solve(capacity);
        System.out.println(solution.toString());
    }
}