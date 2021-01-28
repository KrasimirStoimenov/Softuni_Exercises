--2. Longest Magic Wand

SELECT TOP(1) Max(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY MagicWandSize
ORDER BY MagicWandSize DESC