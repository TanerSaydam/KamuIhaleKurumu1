namespace CleanArchitectureApp.Application.Services;

internal static class GenericService
{
    public static bool IsTcKimlikValid(string tcKimlikNo)
    {
        // T.C. kimlik numarası 11 haneli olmalıdır.
        if (tcKimlikNo.Length != 11)
            return false;

        int sum1 = 0, sum2 = 0;
        int lastDigit, tenthDigit;

        // T.C. kimlik numarası sadece rakam içermelidir.
        if (!long.TryParse(tcKimlikNo, out _))
            return false;

        // İlk hanesi 0 olamaz.
        if (tcKimlikNo[0] == '0')
            return false;

        // İlk 10 hane üzerinde işlemler yapılır.
        for (int i = 0; i < 9; i++)
        {
            int digit = int.Parse(tcKimlikNo[i].ToString());
            if (i % 2 == 0)
                sum1 += digit;
            else
                sum2 += digit;
        }

        // 10. ve 11. haneler hesaplanır.
        tenthDigit = ((sum1 * 7) - sum2) % 10;
        lastDigit = (sum1 + sum2 + tenthDigit) % 10;

        // 10. ve 11. haneler, kimlik numarasının son iki hanesiyle eşleşmelidir.
        return (tenthDigit == int.Parse(tcKimlikNo[9].ToString()) && lastDigit == int.Parse(tcKimlikNo[10].ToString()));
    }
}