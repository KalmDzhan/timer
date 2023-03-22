using TimerApp;

Console.Write("Введите минуты: ");
int minutes = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите секунды: ");
int seconds = Convert.ToInt32(Console.ReadLine());

Console.Clear();

Timer1 time = new(minutes, seconds);

time.Run();