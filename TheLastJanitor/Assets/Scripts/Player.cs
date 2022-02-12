using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	private readonly float _speed = 2;
	private float _stamina = 1;
	private readonly float _staminaLoss = 1f / 100;
	private Animator _animator;
	public Text staminaText;

	private void Start()
	{
		_animator = GetComponent<Animator>();
		InvokeRepeating(nameof(DecreaseStamina), .1f, .5f);
	}

	private void Update()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");

		Vector2 direction = new Vector2(x, y).normalized;
		_animator.SetFloat("Move X", x);

		GetComponent<Rigidbody2D>().velocity = direction * _speed * _stamina;

		//TODO(jonik): Properly implement this fuckery. Updating the value and text every update cycle is probably not a best practice.
	}

	private void DecreaseStamina()
	{
		_stamina -= _staminaLoss;
		_stamina = Mathf.Clamp(_stamina, 0, 1);
		staminaText.text = $"Stamina: {_stamina}";
		Debug.Log($"Stamina: {_stamina}");
	}

	private void Eat()
	{
		_stamina = 1;
	}
}