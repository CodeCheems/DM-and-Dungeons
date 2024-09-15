using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform ItenPoint;//�A�C�e���̕\���J�n�_
    public Transform ShotPoint;//�ˏo����̊J�n�_
    public GameObject ItemPrefab;//�A�C�e����Prefab�X���b�g
    public GameObject ThrowPrefab;//���K�p��Prefab�X���b�g
    public GameObject BowPrefab;//�|�i��j��Prefab�X���b�g
    Rigidbody2D rb;
    Animator animator;
    public float moveSpeed = 1f;

    [SerializeField]
    private Transform shotPointTransform = null;



    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()//�����L�[�Ō��������߂ĉ�����������Walk�ɕ\��
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = (x == 0) ? Input.GetAxisRaw("Vertical") : 0.0f;

        if (x != 0 || y != 0)
        {
            animator.SetFloat("x", x);
            animator.SetFloat("y", y);
            animator.SetBool("Walk", true);
            var newpos = transform.position;
            var speed = Time.deltaTime * 0.5f;
            if (x > 0)
            {
                newpos = new Vector3(newpos.x + speed, newpos.y - speed * 0.5f, 0);
            }
            else if (x < 0)
            {
                newpos = new Vector3(newpos.x - speed, newpos.y + speed * 0.5f, 0);
            }
            else if (y > 0)
            {
                newpos = new Vector3(newpos.x + speed, newpos.y + speed * 0.5f, 0);
            }
            else if (y < 0)
            {
                newpos = new Vector3(newpos.x - speed, newpos.y - speed * 0.5f, 0);
            }
            transform.position = newpos;
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        StartCoroutine(Action());
        StartCoroutine(Shot());
    }
    IEnumerator Action()//�e�s�����L�[�ōĐ�
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetTrigger("Slash");
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            animator.SetTrigger("Guard");
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            animator.SetTrigger("Item");//�e�����œ����ɍ��킹�Ė�r����ɂ�����
            Instantiate(ItemPrefab, ItenPoint.position, transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            animator.SetTrigger("Damage");
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            animator.SetTrigger("Dead");
            this.transform.position = new Vector2(0f, -0.12f);
            for (var i = 0; i < 64; i++)
            {
                yield return null;
            }
            this.transform.position = Vector2.zero;
        }
    }
    IEnumerator Shot()//�ˏo����̑I���ƕ\��
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("Throw");
            for (var i = 0; i < 30; i++)
            {
                // �R���[�`��
                yield return null;
            }
            Instantiate(ThrowPrefab, Vector2.zero, Quaternion.identity, shotPointTransform);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetTrigger("Bow");
            for (var i = 0; i < 40; i++)
            {
                yield return null;
            }
            Instantiate(BowPrefab, Vector2.zero, Quaternion.identity, shotPointTransform);
        }

    }
}




