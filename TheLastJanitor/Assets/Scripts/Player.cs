using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
	private readonly float _speed = 2;
	private float _stamina = 1;
	private readonly float _staminaLoss = 1f / 100;
	public Progressbar staminaBar;
	
	private Animator _animator;

	private void Start()
	{
		_animator = GetComponent<Animator>();
		staminaBar = FindObjectOfType<Progressbar>();
	}

	private void Update()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		Vector2 direction = new Vector2(x, y).normalized;
		_animator.SetFloat("Move X", x);

		GetComponent<Rigidbody2D>().velocity = direction * _speed * _stamina;
		StartCoroutine(DecreaseStamina());
	}
	
	private IEnumerator DecreaseStamina()
	{
		_stamina = Mathf.Clamp(_stamina - _staminaLoss * Time.deltaTime, 0.5f, 1f);
		staminaBar.value = _stamina;
		yield return new WaitForSeconds(1f);
	}

	private void Eat()
	{
		_stamina = 1;
	}
}