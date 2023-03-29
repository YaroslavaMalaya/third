namespace lab_3;

public class StringsDictionary
{
    private const int InitialSize = 10;

    private linked_list[] _buckets = new linked_list[InitialSize];
    
    public void Add(string key, string value)
    {
        var bucketsLength = _buckets.Length;
        var full = 0;
        foreach (var node in _buckets)
        {    
            if (node != null)
            {       
                full++;
            }
        }
        var loadFactor = full/bucketsLength;
        
        if (loadFactor > 0.7)
        {
            var _buckets1 = new linked_list[bucketsLength*2];
            foreach (var list in _buckets)
            {
                foreach (KeyValuePair element in list)
                {
                    var hash1 = CalculateHash(element.Key, _buckets1.Length);
                    if (_buckets1[hash1] == null)
                    {
                        _buckets1[hash1] = new linked_list();
                    }
                    _buckets1[hash1].Add(new (element.Key, element.Value));
                }
            }
            _buckets = _buckets1;
        }
        
        var hash = CalculateHash(key, _buckets.Length);
        if (_buckets[hash] == null)
        {
            _buckets[hash] = new linked_list();
        }

        foreach (KeyValuePair pair in _buckets[hash])
        {
            if (pair.Key == key)
            {
                _buckets[hash].RemoveByKey(key);
            }
        }
        _buckets[hash].Add(new KeyValuePair(key, value));
    }

    public void Remove(string key)
    {
        var hash = CalculateHash(key, _buckets.Length);
        if (_buckets[hash] == null)
        {
            return;
        }
        _buckets[hash].RemoveByKey(key);
    }

    public string Get(string key)
    {
        var hash = CalculateHash(key, _buckets.Length);
        if (_buckets[hash] != null)
        {
            if (_buckets[hash].GetItemWithKey(key) != null)
            {
                var value = _buckets[hash].GetItemWithKey(key).Value;
                return value;
            }
            return "This word doesn't exist in the dictionary :(";
        }
        
        return "This word doesn't exist in the dictionary :(";
    }
    
    private int CalculateHash(string key,  int bucketsLength)
    {
        var number = 1;
        var power = 1;
        foreach (char element in key)
        {
            number += (int) Math.Pow(element, power); // проосить вказати що це саме int 
            power++;
        }
        var hash = (int) (Int64.Abs(number) % bucketsLength); 
        // беру по модулю (Abs), бо іноді з мінусом виходить, 64 бо number буже велике число
        return hash;
    }
    
    public bool Contains(string key) // частинка для додаткового від Влада
    {
        var hash = CalculateHash(key, _buckets.Length);
        if (_buckets[hash] != null)
        {
            foreach (KeyValuePair element in _buckets[hash])
            {
                if (element.Key == key)
                {
                    return true;
                }
            }
        }

        return false;
    }
}