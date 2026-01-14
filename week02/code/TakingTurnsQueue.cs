// TakingTurnsQueue.cs
// This class manages a queue of Person objects, each with a certain number of turns.
// Scenario: Supports finite turns (positive integer), infinite turns (zero or negative),
// and throws an exception when the queue is empty.
// Expected Results: 
// - Finite turns: Person is re-enqueued until their turns run out, then removed.
// - Infinite turns: Person is always re-enqueued regardless of turn count.
// - Empty queue: GetNextPerson() throws InvalidOperationException with message "No one in the queue."
// Defect(s) Found: None. All test cases (finite repetition, adding players midway, infinite turns, empty queue)
// passed successfully with this implementation.

using System;

public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
            throw new InvalidOperationException("No one in the queue.");

        Person person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Infinite turns → always re-enqueue
            _people.Enqueue(person);
        }
        else
        {
            person.Turns -= 1;
            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }

        return person;
    }

    public override string ToString() => _people.ToString();
}
