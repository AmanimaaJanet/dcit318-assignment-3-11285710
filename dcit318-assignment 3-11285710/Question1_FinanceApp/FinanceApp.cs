public class FinanceApp
{
    private List<Transaction> _transactions;

    public FinanceApp()
    {
        _transactions = new List<Transaction>();
    }

    public void Run()
    {
        // i. Instantiate a SavingsAccount
        SavingsAccount savingsAccount = new SavingsAccount("SAV001", 1000m);

        // ii. Create three Transaction records
        Transaction transaction1 = new Transaction(1, DateTime.Now, 150.00m, "Groceries");
        Transaction transaction2 = new Transaction(2, DateTime.Now, 89.00m, "Utilities");
        Transaction transaction3 = new Transaction(3, DateTime.Now, 45.00m, "Entertainment");

        // iii. Use processors to process each transaction
        MobileMoneyProcessor mobileProcessor = new MobileMoneyProcessor();
        BankTransferProcessor bankProcessor = new BankTransferProcessor();
        CryptoWalletProcessor cryptoProcessor = new CryptoWalletProcessor();

        mobileProcessor.Process(transaction1);
        bankProcessor.Process(transaction2);
        cryptoProcessor.Process(transaction3);

        // iv. Apply each transaction to the SavingsAccount
        savingsAccount.ApplyTransaction(transaction1);
        savingsAccount.ApplyTransaction(transaction2);
        savingsAccount.ApplyTransaction(transaction3);

        // v. Add all transactions to _transactions
        _transactions.Add(transaction1);
        _transactions.Add(transaction2);
        _transactions.Add(transaction3);
    }
}