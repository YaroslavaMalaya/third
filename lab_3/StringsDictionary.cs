namespace lab_3;

public class StringsDictionary
{
    private const int InitialSize = 10;

    private LinkedList<KeyValuePair>[] _buckets = new LinkedList<KeyValuePair>[InitialSize];
    
    public void Add(string key, string value)
    {
        var bucketsLength = _buckets.Length;
        var full = 0;
        foreach (var node in _buckets)
        {    if (node != null)
            {       
                full++;
            }
            
        }
        var loadFactor = full/bucketsLength;
        
        var hash = CalculateHash(key);
        if (_buckets[hash] == null)
        {
            _buckets[hash] = new LinkedList<KeyValuePair>();
        }
        _buckets[hash].AddLast(new KeyValuePair(key, value)); //  потім замінити AddLast на наш Add
    }

    public void Remove(string key)
    {
        var hash = CalculateHash(key);
        if (_buckets[hash] == null)
        {
            return;
        }

        var head = _buckets[hash].First; // замінити потім на наш _first
        while (head != null)
        {
            if (head.Value.Key == key)
            {
                _buckets[hash].Remove(head);
                return;
            }
            head = head.Next;
        }
    }

    public string Get(string key)
    {
        var hash = CalculateHash(key);
        if (_buckets[hash] != null)
        {
            foreach (var element in _buckets[hash])
            {
                if (element.Key == key)
                {
                    return element.Value;
                }
            }
        }
        return "This word doesn't exist in the dictionary :(";
    }
    
    private int CalculateHash(string key)
    {
        var number = 1;
        var power = 1;
        foreach (char element in key)
        {
            number += (int) Math.Pow(element, power); // проосить вказати що це саме int 
            power++;
        }
        var hash = (int) (Int64.Abs(number) % _buckets.Length); 
        // беру по модулю (Abs), бо іноді з мінусом виходить, 64 бо number буже велике число
        return hash;
    }
}