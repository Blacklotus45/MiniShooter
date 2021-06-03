public class LockUpdate
{ 
    private bool _lock = false;

    public bool Lock => _lock;

    public void ToggleLock()
    {
        _lock = !_lock;
    }
}